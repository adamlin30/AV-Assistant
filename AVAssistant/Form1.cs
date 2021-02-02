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
    public partial class AV_Assistant : Form
    {
        public string videoFolder = null;
        public string[] drives = { @"E:\", @"D:\", @"C:\", @"F:\", @"H:\" };
        FileUtility fileUtility = new FileUtility();
        FolderUtility folderUtility = new FolderUtility();
        Video video = new Video();
        Actress actress = new Actress();

        public AV_Assistant()
        {
            InitializeComponent();
            avTabControl.SelectedIndex = 2;
            thumbnailBrowser.Hide();
            coverPictureBox.Show();
            //coverPictureBox.Location = new Point(664, 27);

            fileUtility.DownloadCover(this.wgetLinks, this.studioDataGridView);
            actressDataGridView.DataSource = fileUtility.ReadCSV(@"E:\temp\AV_Actress_C.csv"); //read csv file

            video.drives = drives;
            actress.drives = drives;
            actress.ListActress(this.actressListBox, this.actressDataGridView);
            video.ListVideo(this.videoListBox, this.videoDataGridView, this.numOfFile);
            //fileUtility.ShowThumbnail(this.thumbnailBrowser);
            video.ListGenre(genreDataGridView);
        }

        private void videoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoFileTreeView.Nodes.Clear();
            coverPictureBox.Image = null;

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
                    fileUtility.GetFileSize(this.fileSize, s.FullName);

                }
                videoFileTreeView.Nodes.Add(root);
            }
        }

        private void videoListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fileUtility.CallExecutable(@"C:\Windows\explorer.exe", videoFolder); //open video folder
        }

        private void videoListBox_MouseDown(object sender, MouseEventArgs e)
        {
            videoListBox.SelectedIndex = videoListBox.IndexFromPoint(e.X, e.Y); //mouse right-click
        }

        private void videoFileTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            fileUtility.GetFileSize(this.fileSize, Path.Combine(videoFolder, e.Node.FullPath));
        }

        private void videoFileTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string fileType = @"*.avi; *.mkv; *.mp4; *.mpg; *.wmv";

            if (fileType.Contains(Path.GetExtension(e.Node.Text)))
            {
                fileUtility.CallExecutable(@"PotPlayerMini64.exe", Path.Combine(videoFolder, e.Node.FullPath));
            }
        }

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

                foreach (string s in actress.actressNameFromFolderArr)
                {
                    if (filteredActressArr.Contains(s))
                    {
                        actressListBox.Items.Add(s);
                    }
                }

                if (rankCheckedListBox.CheckedItems.Count == 0)
                {
                    actress.ListActress(this.actressListBox, this.actressDataGridView);
                }
            }));
        }

        private void thumbnailBrowser_MouseHover(object sender, EventArgs e)
        {
            thumbnailBrowser.Focus(); //enable mouse wheel
        }

        private void nameAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.sortBy = "Video ASC";
            video.ListVideo(this.videoListBox, this.videoDataGridView, this.numOfFile);
        }

        private void nameDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.sortBy = "Video DESC";
            video.ListVideo(this.videoListBox, this.videoDataGridView, this.numOfFile);
        }

        private void timeAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.sortBy = "Creation Time ASC";
            video.ListVideo(this.videoListBox, this.videoDataGridView, this.numOfFile);
        }

        private void timeDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video.sortBy = "Creation Time DESC";
            video.ListVideo(this.videoListBox, this.videoDataGridView, this.numOfFile);
        }

        private void searchCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com.tw/?gws_rd=ssl#q=" + videoListBox.Text + "+dmm+jpg");
        }

        private void sortActressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] cIDActress = videoFolder.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            actressListBox.Text = cIDActress[1];
            avTabControl.SelectedIndex = 1;

            rankCheckedListBox.SetItemChecked(0, true);
            this.BeginInvoke(new Action(() =>
            {
                int index = actressListBox.Items.IndexOf(cIDActress[1]);
                actressListBox.SetSelected(index, true);
            }
            ));
            //need to enable address-score
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
            //column video of AV video compares with column video of AV genre
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

            string[] addToGenre = colVideo.Except(colGenre).ToArray(); //add to genre
            string[] removeFromGenre = colGenre.Except(colVideo).ToArray(); //remove from genre

            foreach (string s in removeFromGenre)
            {
                int removeIndex = Array.IndexOf(colGenre, s);
                dtGenre.Rows.Remove(dtGenre.Rows[removeIndex]);
            }

            foreach (string s in addToGenre)
            {
                dtGenre.Rows.Add(s, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }

            genreDataGridView.DataSource = dtGenre;
            MessageBox.Show("Record(s) Removed : " + removeFromGenre.Count() + "\n"
                          + "Record(s) Added      : " + addToGenre.Count() + "\n"
                          + "Total Records            : " + genreDataGridView.Rows.Count);
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
                        gnereSelected.Add(i.ToString()); //check ranking selected
                    }
                }

                string[] genreSelectedArr = gnereSelected.ToArray();
                int numOfGenreSelected = genreSelectedArr.Count();
                int sum = 0;
                int counter = 0;

                for (int i = 0; i < genreDataGridView.Rows.Count - 1; i++) //the last row is empty
                {
                    sum = 0;
                    for (int j = 0; j < numOfGenreSelected; j++)
                    {
                        int columnVal = int.Parse(genreSelectedArr[j]);
                        sum = sum + int.Parse(genreDataGridView.Rows[i].Cells[columnVal + 1].Value.ToString());
                    }

                    if (numOfGenreSelected == sum)
                    {
                        videoListBox.Items.Add(genreDataGridView.Rows[i].Cells[0].Value.ToString());
                        counter++;
                    }
                    numOfFile.Text = counter.ToString();
                }

                if (genreCheckedListBox.CheckedItems.Count == 0)
                {
                    video.ListVideo(this.videoListBox, this.actressDataGridView, this.numOfFile);
                }

            }));

        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form genreForm = new Form();
            genreForm.MinimizeBox = false;
            genreForm.MaximizeBox = false;
            genreForm.Text = "Genre Editor";
            genreForm.Height = 620;
            genreForm.Width = 940;
            //genreForm.TopMost = true;
            genreForm.Show();
            genreForm.Controls.Add(genreDataGridView);
            genreForm.Controls.Add(updateGenreButton);
            genreForm.Controls.Add(exportGenreButton);

            genreDataGridView.Size = new Size(910, 498);
            genreDataGridView.Location = new Point(0, 0);
            updateGenreButton.Location = new Point(0, 500);
            exportGenreButton.Location = new Point(500, 500);

            genreForm.FormClosing += genreForm_FormClosing; //detect x button event

        }

        private void genreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form f = sender as Form;
            Form f = (Form)sender;
            e.Cancel = true; //http://www.frogjumpjump.com/2018/12/windows-form.html
            f.Hide();

        }
    }
}
