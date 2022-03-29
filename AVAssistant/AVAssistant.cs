using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using AVAssistantLibrary;
using System.Diagnostics;

namespace AVAssistant
{
    public partial class avAssistantForm : Form
    {
        public string videoFolder = null;
        public string[] drives = { @"C:\", @"D:\", @"E:\", @"F:\", @"H:\" };
        FileUtility fileUtility = new FileUtility();
        FolderUtility folderUtility = new FolderUtility();
        Video video = new Video();
        Actress actress = new Actress();
        Global global = new Global();
        
        public avAssistantForm()
        {
            InitializeComponent();
            avTabControl.SelectedIndex = 2;
            thumbnailBrowser.Hide();
            coverPictureBox.Show();
            //coverPictureBox.Location = new Point(664, 27);
            
            fileUtility.DownloadCover(this.coverLinkTextBox, this.studioDataGridView);
            Global.ScanDrive(drives); // Scan all drives first and list all video folders
            //video.drives = drives;
            //actress.drives = drives;
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
            video.ListGenre(genreDataGridView);
            actress.UpdateActress(this.actressListBox, this.actressDataGridView, this.actressRenameToolStripComboBox);

        }

        private void avTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (avTabControl.SelectedIndex == 1)
            {
                thumbnailBrowser.Show();
                coverPictureBox.Hide();
            }

            if (avTabControl.SelectedIndex == 2)
            {
                thumbnailBrowser.Hide();
                coverPictureBox.Show();
                //coverPictureBox.Location = new Point(564, 27);
            }
        }

        //*****Actress Mode*****//
        private void actressListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            actressVideoTreeView.Nodes.Clear();
            thumbnailBrowser.Controls.Clear();

            TreeNode childNode;
            var allSubDirs = new List<DirectoryInfo>();
            int counter = 0;
            foreach (var d in drives)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                DirectoryInfo[] subDirs = di.GetDirectories(@"* - " + actressListBox.Text); //AAA-111 - Julia
                var fileUtility = new FileUtility();

                for (int i = 0; i < subDirs.Length; i++)
                {
                    TreeNode root = new TreeNode(subDirs[i].ToString());
                    actressVideoTreeView.Nodes.Add(root); //add folder to tree

                    DirectoryInfo sdi = new DirectoryInfo(subDirs[i].FullName);
                    FileInfo[] subFiles = sdi.GetFiles();

                    foreach (FileInfo sub in subFiles)
                    {
                        childNode = new TreeNode(sub.Name, 0, 0);
                        root.Nodes.Add(childNode); //add files to tree
                        if (sub.FullName.Contains(Regex.Match(root.Text, @"^.*?(?= )").ToString() + ".jpg"))
                        {
                            fileUtility.ShowThumbnail(this.thumbnailBrowser, this.actressVideoTreeView, this.videoDataGridView, sub.FullName);
                        }
                    }
                    counter++;
                }
            }

            VideoNumActressMode.Text = counter.ToString();

            /*if (i == 0 && subFiles.Length != 0)
            {
                fileUtility.ShowImage(this.coverPictureBox, Path.ChangeExtension(subFiles[0].FullName, ".jpg"));
            }*/

        }

        private void rankCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            thumbnailBrowser.Controls.Clear();
            actressListBox.Items.Clear();
            actressVideoTreeView.Nodes.Clear();
            List<string> rankSelected = new List<string>();

            //https://stackoverflow.com/questions/32291324/manage-checkedlistbox-itemcheck-event-to-run-after-an-item-checked-not-before
            this.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i <= (rankCheckedListBox.Items.Count - 1); i++)
                {
                    if (rankCheckedListBox.GetItemChecked(i))
                    {
                        rankSelected.Add(rankCheckedListBox.Items[i].ToString()); //check ranking selected
                    }
                }

                string[] rankSelectedArr = rankSelected.ToArray();

                List<string> filteredActress = new List<string>();

                foreach (DataGridViewRow row in actressDataGridView.Rows)
                {
                    if (row.Cells[1].Value != null) //need to check for null if new row is exposed
                    {
                        //https://stackoverflow.com/questions/13284259/c-sharp-if-string-contains-more-than-1-value
                        if (rankSelectedArr.Any(v => row.Cells[1].Value.ToString().Contains(v))) //(Julia, 10) = 10?
                        {
                            filteredActress.Add(actressDataGridView.Rows[row.Index].Cells[0].Value.ToString());
                            //search score for all actresses including retired actress
                        }
                    }
                }

                string[] filteredActressArr = filteredActress.ToArray();
                actressListBox.Items.Clear();

                foreach (string s in actress.ActressNameFromFolderArr)
                {
                    if (filteredActressArr.Contains(s))
                    {
                        actressListBox.Items.Add(s);
                    }
                }

                if (rankCheckedListBox.CheckedItems.Count == 0)
                {
                    actress.UpdateActress(this.actressListBox, this.actressDataGridView, this.actressRenameToolStripComboBox);
                }
            }));
        }

        //*****Video Mode*****//
        private void videoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoFileTreeView.Nodes.Clear();
            coverPictureBox.Image = null;

            if (!String.IsNullOrEmpty(videoListBox.Text))
            {
                videoFolder = Path.Combine(fileUtility.SearchVideoDrive(this.videoDataGridView, videoListBox.Text));

                DirectoryInfo di = new DirectoryInfo(videoFolder);
                FileInfo[] subFiles = di.GetFiles();

                foreach (FileInfo s in subFiles)
                {
                    TreeNode root = new TreeNode(s.Name);
                    if (s.Name.Contains(@".jpg"))
                    {
                        fileUtility.ShowImage(this.coverPictureBox, s.FullName);  //shows AV cover if jpg exists 
                    }

                    string fileType = @"*.avi; *.mkv; *.mp4; *.mpg; *.wmv; *.iso";
                    if (fileType.Contains(Path.GetExtension(s.Name)))
                    {
                        fileUtility.GetFileSize(this.fileSizeTextBox, s.FullName);

                    }
                    videoFileTreeView.Nodes.Add(root);
                }
            }
            else
            {
                videoFolder = null;
            }
        }

        private void videoListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(videoFolder))
            {
                fileUtility.CallExecutable(@"C:\Windows\explorer.exe", videoFolder); //open video folder
            }
        }

        private void videoListBox_MouseDown(object sender, MouseEventArgs e)
        {
            videoListBox.SelectedIndex = videoListBox.IndexFromPoint(e.X, e.Y); //mouse right-click
        }

        private void videoFileTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            fileUtility.GetFileSize(this.fileSizeTextBox, Path.Combine(videoFolder, e.Node.FullPath));
        }

        private void videoFileTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string fileType = @"*.avi; *.mkv; *.mp4; *.mpg; *.wmv";

            if (fileType.Contains(Path.GetExtension(e.Node.Text)))
            {
                fileUtility.CallExecutable(@"PotPlayerMini64.exe", Path.Combine(videoFolder, e.Node.FullPath));
            }
        }

        private void genreCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            coverPictureBox.Image = null;
            videoListBox.Items.Clear();
            videoFileTreeView.Nodes.Clear();
            List<string> gnereSelected = new List<string>();

            //https://stackoverflow.com/questions/32291324/manage-checkedlistbox-itemcheck-event-to-run-after-an-item-checked-not-before
            this.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i <= (genreCheckedListBox.Items.Count - 1); i++)
                {
                    if (genreCheckedListBox.GetItemChecked(i))
                    {
                        gnereSelected.Add(i.ToString()); // Check ranking selected
                    }
                }

                string[] genreSelectedArr = gnereSelected.ToArray();
                int numOfGenreSelected = genreSelectedArr.Count();
                int sum = 0;
                int counter = 0;

                for (int i = 0; i < genreDataGridView.Rows.Count - 1; i++) // Skip the last row
                {
                    sum = 0;
                    for (int j = 0; j < numOfGenreSelected; j++)
                    {
                        int columnVal = int.Parse(genreSelectedArr[j]); // 0:bondage 1:classic etc.
                        sum = sum + int.Parse(genreDataGridView.Rows[i].Cells[columnVal + 1].Value.ToString());
                    }

                    if (numOfGenreSelected == sum)
                    {
                        videoListBox.Items.Add(genreDataGridView.Rows[i].Cells[0].Value.ToString());
                        counter++;
                    }
                    numOfFileTextBox.Text = counter.ToString();
                }

                if (genreCheckedListBox.CheckedItems.Count == 0)
                {
                    video.UpdateVideo(this.videoListBox, this.actressDataGridView, this.numOfFileTextBox);
                }
            }));
        }

        //*****Mouse Menu*****//
        private void actressAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.SortBy = "Actress ASC";
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
        }

        private void actressDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.SortBy = "Actress DESC";
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
        }

        private void videoAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.SortBy = "Video ASC";
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
        }

        private void videoDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.SortBy = "Video DESC";
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
        }

        private void timeAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.SortBy = "Creation Time ASC";
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
        }

        private void timeDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.SortBy = "Creation Time DESC";
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
        }

        private void searchCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/search?q=" + videoListBox.Text + "+dmm+jpg");
        }

        private void copyActressNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] cIDActress = videoListBox.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            Clipboard.SetText(cIDActress[1]);
        }

        private void copyVideoIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] cIDActress = videoListBox.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            Clipboard.SetText(cIDActress[0]);
        }

        private void sortActressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rankCheckedListBox.Items.Count; i++)
            {
                rankCheckedListBox.SetItemChecked(i, false); //uncheck the previously ranking
            }
            actressListBox.ClearSelected();

            string[] cIDActress = videoListBox.Text.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (cIDActress.Length == 2)
            {
                actressListBox.Text = cIDActress[1]; //0:cID 1:actress
                int score = -999;

                foreach (DataGridViewRow row in actressDataGridView.Rows)
                {
                    if (row.Cells[0].Value != null) //skip the last row
                    {
                        //find the corresponding score for the actress
                        if (actressListBox.Text.All(v => row.Cells[0].Value.ToString().Contains(v)))
                        {
                            score = int.Parse(row.Cells[1].Value.ToString());
                        }
                    }
                }

                score = (score >= 5) ? 10 - score : 6; //score to rankCheckedListBox mapping

                rankCheckedListBox.SetItemChecked(score, true);
                this.BeginInvoke(new Action(() =>
                {
                    //highlight the actress
                    actressListBox.SetSelected(actressListBox.Items.IndexOf(cIDActress[1]), true);
                }
                ));

                avTabControl.SelectedIndex = 1;
            }
        }

        //*****Menu*****//
        private void avActresscsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileUtility.CallExecutable(@"notepad++.exe", "E:\\temp\\AV_Actress_C.csv");
        }

        private void avStudiocsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileUtility.CallExecutable(@"notepad++.exe", "E:\\temp\\AV_Studio_C.csv");
        }

        public Form genreForm = new Form();

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dynamically generate a new form as Genre Editor
            genreForm.MinimizeBox = false;
            genreForm.MaximizeBox = false;
            genreForm.Text = "Genre Editor";
            genreForm.Height = 680;
            genreForm.Width = 940;
            //genreForm.TopMost = true;
            genreForm.Show();
            genreForm.Controls.Add(genreDataGridView);
            genreForm.Controls.Add(updateGenreButton);
            genreForm.Controls.Add(exportGenreButton);
            genreForm.Controls.Add(label1);

            genreDataGridView.Size = new Size(910, 498);
            genreDataGridView.Location = new Point(0, 0);
            updateGenreButton.Location = new Point(0, 500);
            exportGenreButton.Location = new Point(500, 500);
            label1.Location = new Point(200, 500);


            genreForm.FormClosing += genreForm_FormClosing; // Event for detect close window
            genreDataGridView.SelectionChanged += genreDataGridView_SelectionChanged; // Event for sync the selection
            // 2022/01/15: Sort the videoListBox by name ascending
            videoAscendingToolStripMenuItem_Click(sender, e);
            videoListBox.SetSelected(0, true); // 2022/01/15: Always select the first video

            genreDataGridView.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in genreDataGridView.Rows)
            {
                int score = 0;
                for (int i = 1; i < genreDataGridView.ColumnCount; i++)
                {
                    score = score + Convert.ToInt32(row.Cells[i].Value); //check if the video is classfied
                }
                if (score == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            genreForm.Dispose(); // Force genreForm to close
            Application.Restart();
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alwaysOnTopToolStripMenuItem.Checked = !alwaysOnTopToolStripMenuItem.Checked;
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            genreForm.Dispose(); // Force genreForm to close
            Application.Exit();
        }

        private void exportGenreButton_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/56138612/c-sharp-save-datagridview-to-text-file
            TextWriter tw = new StreamWriter(@"E:\temp\test.csv");

            for (int i = 0; i < genreDataGridView.ColumnCount; i++) //write headers to the file
            {
                tw.Write(genreDataGridView.Columns[i].HeaderText);
                if (i != genreDataGridView.Columns.Count - 1)
                {
                    tw.Write(",");
                }
            }

            tw.WriteLine();

            for (int i = 0; i < genreDataGridView.Rows.Count - 1; i++) //write body to the file
            {
                for (int j = 0; j < genreDataGridView.Columns.Count; j++)
                {
                    tw.Write(genreDataGridView.Rows[i].Cells[j].Value.ToString());
                    if (j != genreDataGridView.Columns.Count - 1)
                    {
                        tw.Write(",");
                    }
                }
                tw.WriteLine();
            }
            tw.Close();
        }

        private void updateGenreButton_Click(object sender, EventArgs e)
        {
            //compare number of videos of AV video with the one of AV genre
            DataTable dtVideo = (DataTable)(videoDataGridView.DataSource);
            string[] colVideo = new string[dtVideo.Rows.Count];

            for (int i = 0; i < dtVideo.Rows.Count; i++)
            {
                colVideo[i] = dtVideo.Rows[i]["Video"].ToString(); //build a video array
            }

            DataTable dtGenre = (DataTable)(genreDataGridView.DataSource);
            string[] colGenre = new string[dtGenre.Rows.Count];

            for (int i = 0; i < dtGenre.Rows.Count; i++)
            {
                colGenre[i] = dtGenre.Rows[i]["Video"].ToString(); //build a genre array
            }

            string[] addToGenre = colVideo.Except(colGenre).ToArray(); //videos added to genre table
            string[] removeFromGenre = colGenre.Except(colVideo).ToArray(); //videos removed from genre table

            foreach (string r in removeFromGenre)
            {
                int removeIndex = Array.IndexOf(colGenre, r); //find video is not present
                colGenre = colGenre.Where((val, idx) => idx != removeIndex).ToArray(); //delete an element from an array
                //https://stackoverflow.com/questions/496896/how-to-delete-an-element-from-an-array-in-c-sharp
                dtGenre.Rows.Remove(dtGenre.Rows[removeIndex]); //delete an element from the table array
            }

            foreach (string a in addToGenre)
            {
                dtGenre.Rows.Add(a, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0); // add an element to the table
            }

            genreDataGridView.DataSource = dtGenre;
            MessageBox.Show("Record(s) Removed : " + removeFromGenre.Count() + "\n"
                          + "Record(s) Added      : " + addToGenre.Count() + "\n"
                          + "Total Records            : " + (genreDataGridView.Rows.Count - 1));

            foreach (DataGridViewRow row in genreDataGridView.Rows)
            {
                int score = 0;
                for (int i = 1; i < genreDataGridView.ColumnCount; i++)
                {
                    score = score + Convert.ToInt32(row.Cells[i].Value); //check if the video is classfied
                }
                if (score == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void genreDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // 2022/01/15: Sync the selection between videoListBox and genreDataGridView
            videoListBox.SetSelected(genreDataGridView.CurrentRow.Index, true);
        }

        private void genreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form f = sender as Form;
            Form f = (Form)sender;
            e.Cancel = true; //http://www.frogjumpjump.com/2018/12/windows-form.html
            f.Hide(); //hide new form
        }

        //*****Visualization*****//
        private void thumbnailBrowser_MouseHover(object sender, EventArgs e)
        {
            thumbnailBrowser.Focus(); //enable mouse wheel
        }

        private void videoFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            videoListBox.Items.Clear();
            if (string.IsNullOrEmpty(videoFilterTextBox.Text) == false)
            {
                foreach (string s in video.VideoListBoxItems)
                {
                    if (s.ToLower().Contains(videoFilterTextBox.Text))
                    {
                        videoListBox.Items.Add(s);
                    }
                }
                numOfFileTextBox.Text = videoListBox.Items.Count.ToString();
            }
            else if (videoFilterTextBox.Text == "")
            {
                foreach (string s in video.VideoListBoxItems)
                {
                    videoListBox.Items.Add(s);
                }
                numOfFileTextBox.Text = videoListBox.Items.Count.ToString();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedVideo = this.videoListBox.SelectedIndex; // Get current video index

            var confirmResult = MessageBox.Show("Are you sure to delete " + videoFolder + "??", "CONFIRM DELETE!!", MessageBoxButtons.OKCancel);
            // read only problem
            if (confirmResult == DialogResult.OK)
            {
                folderUtility.DeleteDirectory(videoFolder, true);
                Global.ScanDrive(drives);
                video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
                video.ListGenre(genreDataGridView);
                coverPictureBox.Image = null;
            }

            this.videoListBox.SelectedIndex = selectedVideo; // 2022/01/15: Select the next video
        }

        public Form renameForm = new Form();

        private void actressRenameToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoListContextMenuStrip.Hide();
            //MessageBox.Show(actressToolStripComboBox.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(actressRenameToolStripComboBox.SelectedItem.ToString())) // if no actress name pciked, skip renaming
            {
                if (actressRenameToolStripComboBox.SelectedItem.ToString() == "NEW NAME")
                {
                    //https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms

                    renameForm.Width = 200;
                    renameForm.Height = 150;
                    renameForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    renameForm.Text = "Enter New Actress Name";
                    renameForm.StartPosition = FormStartPosition.CenterScreen;

                    Label label = new Label() { Left = 50, Top = 10, Text = "Actress Name:" };
                    TextBox textBoxActressName = new TextBox() { Left = 50, Top = 40, Width = 100 };
                    Button confirmButton = new Button() { Text = "OK", Left = 50, Top = 70, Width = 100, DialogResult = DialogResult.OK };
                    renameForm.Controls.Add(label);
                    renameForm.Controls.Add(textBoxActressName);
                    renameForm.Controls.Add(confirmButton);
                    renameForm.AcceptButton = confirmButton;
                    renameForm.TopLevel = true;
                    //prompt.Dock = DockStyle.Top;
                    confirmButton.Click += (sender1, e1) => ConfirmButton_Click(sender1, e1, textBoxActressName.Text);
                    //this.Controls.Add(prompt);
                    renameForm.Show();
                }
                else
                {
                    Rename(actressRenameToolStripComboBox.SelectedItem.ToString());
                }
            }
        }

        public void ConfirmButton_Click(object sender, EventArgs e, string newActressName)
        {
            // MessageBox.Show("");
            renameForm.Hide();
            Rename(newActressName); // Start to rename
        }

        public void Rename(string actressName)
        {
            DirectoryInfo di = new DirectoryInfo(videoFolder);
            FileInfo[] subFiles = di.GetFiles();

            string fileType = @"*.jpg; *.avi; *.mkv; *.mp4; *.mpg; *.wmv; *.iso";

            foreach (FileInfo sub in subFiles)
            {
                if (fileType.Contains(Path.GetExtension(sub.FullName)))
                {
                    File.Move(sub.FullName, Path.Combine(videoFolder, videoListBox.Text + Path.GetExtension(sub.FullName)));
                }
                else
                {
                    File.Delete(sub.FullName);
                }
            }
            Directory.Move(videoFolder, videoFolder + " - " + actressName);
            actress.UpdateActress(this.actressListBox, this.actressDataGridView, this.actressRenameToolStripComboBox);
            Global.ScanDrive(drives);
            video.UpdateVideo(this.videoListBox, this.videoDataGridView, this.numOfFileTextBox);
            video.ListGenre(genreDataGridView);
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            videoFilterTextBox.Text = "";
        }
    }
}
