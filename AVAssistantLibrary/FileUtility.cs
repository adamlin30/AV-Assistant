using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics; //process
using System.Drawing;
using System.Windows;
using System.Threading;

namespace AVAssistantLibrary
{
    public class FileUtility
    {
        //https://immortalcoder.blogspot.com/2013/12/convert-csv-file-to-datatable-in-c.html
        public DataTable ReadCSV(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();

            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }

            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            sr.Close();
            return dt;
        }

        public void DownloadCover(TextBox tb, DataGridView dgv) //download AV cover when initializing program
        {
            var coverNotFoundDirs = new List<string>(); //build array for cover not found in directories

            DataTable dt = new DataTable();
            dt = ReadCSV(@"E:\temp\AV_Studio_C.csv"); //read csv file
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 500;

            string[] maker = new string[dt.Rows.Count];
            string[] link = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                maker[i] = dt.Rows[i]["MAKER"].ToString(); //build an av maker array
                link[i] = dt.Rows[i]["LINK"].ToString(); //build a cover link array
            }

            DirectoryInfo di = new DirectoryInfo(@"E:\"); //for root/unorganized drive only, no need to visit all drives
            DirectoryInfo[] subDirs = di.GetDirectories();
            foreach (DirectoryInfo s in subDirs)
            {
                if (Regex.Match(s.Name, @"^\w+-\d+$").Success) //folder AAA-111 exists?
                {
                    if (!File.Exists(s.FullName + "\\" + s.Name + ".jpg")) //file AAA-111.jpg doesn't exists?
                    {
                        coverNotFoundDirs.Add(s.ToString()); //add folder to list

                        //cID format: Maker-Number (ex. AAA-111)
                        string cID = s.Name;
                        string[] cIDMakerNumber = cID.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                        //int makerIndex = Array.IndexOf(maker, cIDMakerNumber[0]); //find index from the av maker array
                        int[] makerIndex = maker.Select((b, i)
                            => b == cIDMakerNumber[0] ? i : -1).Where(i => i != -1).ToArray();

                        if (makerIndex.Length > 0)
                        {
                            foreach (int m in makerIndex)
                            {
                                string afterMatch = link[m].Substring(link[m].IndexOf(cIDMakerNumber[0].ToLower()) + cIDMakerNumber[0].Length);
                                //https://stackoverflow.com/questions/8224270/regular-expression-to-get-all-characters-before
                                string beforeMatch = Regex.Match(afterMatch, @"^.*?(?=/)").ToString(); //find old number from http link
                                string trimBeforeMatch = Regex.Match(beforeMatch, @"^.*?(?=so)").ToString();
                                if (String.IsNullOrEmpty(trimBeforeMatch))
                                {
                                    trimBeforeMatch = beforeMatch;
                                }

                                int oldNum = trimBeforeMatch.Length;
                                int newNum = cIDMakerNumber[1].Length;
                                int offset = oldNum - newNum;
                                string newID = "";

                                if (offset >= 0)
                                {
                                    newID = trimBeforeMatch.Remove(offset, newNum);
                                    newID = newID.Insert(offset, cIDMakerNumber[1]);
                                }

                                string newLink = link[m].Replace(trimBeforeMatch, newID); //replace old number with new number
                                string coverFilename = s.FullName + "\\" + s.Name + ".jpg";
                                string arg = newLink + @" -O " + s.FullName + "\\" + s.Name + ".jpg" + " -T 3";

                                CallExecutable(@"E:\temp\wget.exe", arg);

                                Thread.Sleep(800);
                                if (new FileInfo(coverFilename).Length == 0)
                                {
                                    File.Delete(coverFilename);
                                }
                                else
                                {
                                    tb.Text = tb.Text + newLink + "\r\n";
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            tb.Text = tb.Text + "\r\n" + string.Join("\r\n", coverNotFoundDirs.ToArray());
        }

        public void CallExecutable(string exeFilePath, string arguments)
        {
            Process exe = new Process();
            exe.StartInfo.FileName = exeFilePath;
            exe.StartInfo.Arguments = arguments;

            if (exeFilePath.Contains(@"wget.exe")) // set wget.exe as a background process
            {
                exe.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            else
            {
                exe.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            }

            exe.Start();
        }

        public void GetFileSize(TextBox tb, string fileName)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = new FileInfo(fileName).Length;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            tb.Text = String.Format("{0:0.##} {1}", len, sizes[order]);
            //return String.Format("{0:0.##} {1}", len, sizes[order]);
        }

        //search corresponding drive for selected video from videoDataGridView
        public string SearchVideoDrive(DataGridView dgv, string selectedVideo)
        {
            DataTable dt = (DataTable)(dgv.DataSource);
            DataRow[] dr = dt.Select("Video = '" + selectedVideo + "'"); //https://stackoverflow.com/questions/6363448/how-can-i-select-a-row-from-a-datatable-using-two-variable-values
            int index = dt.Rows.IndexOf(dr[0]);

            return dt.Rows[index]["Drive"].ToString() + selectedVideo; //E:\\AAA-111 - Julia
        }

        public void ShowImage(PictureBox pb, string imageFile)
        {
            if (File.Exists(imageFile))
            {
                Image img;
                try
                {
                    using (var imgTemp = new Bitmap(imageFile))
                    {
                        img = new Bitmap(imgTemp);
                        pb.Image = img;
                    }
                }
                catch (Exception)
                {
                    pb.Image = null;
                }
            }
        }

        //https://stackoverflow.com/questions/23443901/click-event-in-flowlayoutpanel
        public void ShowThumbnail(FlowLayoutPanel flp, TreeView tv, DataGridView dgv, string imageFile)
        {
            PictureBox img = new PictureBox();

            using (FileStream image = new FileStream(imageFile, FileMode.Open))
            {
                img.Image = Image.FromStream(image);
                //https://blog.csdn.net/LongtengGensSupreme/article/details/69421897
            }
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Dock = DockStyle.Top;
            img.Height = 269; //cover resolution 800x538
            img.Width = 400;
            //imageViewer.Margin = new Padding(0, 0, 0, 0);
            flp.Controls.Add(img);

            //add events to programmatically created PictureBox
            img.Click += (sender, e) => ThumbnailViewer_Click(sender, e, tv);
            //click the thumbnail, highlight the folder
            img.MouseDoubleClick += (sender, e) => ThumbnailViewer_MouseDoubleClick(sender, e, tv, dgv);
            //double click the thumbnail, open the video
            img.MouseEnter += (sender, e) => ThumbnailViewer_MouseEnter(sender, e);
            img.MouseLeave += (sender, e) => ThumbnailViewer_MouseLeave(sender, e);
            img.Tag = imageFile; // cover path stored in the tag
            //img.Dispose();
        }

        private void ThumbnailViewer_Click(object sender, EventArgs e, TreeView tv)
        {
            PictureBox clickedImage = (PictureBox)sender;

            /*for (int i = 0; i < tv.Nodes.Count; i++)
            {
                tv.SelectedNode = tv.Nodes[i];
                tv.SelectedNode.Collapse(); //collapse the node if not selected
            }*/
            f.Hide();
            tv.CollapseAll();

            for (int i = 0; i < tv.Nodes.Count; i++)
            {
                if (clickedImage.Tag.ToString().Contains(tv.Nodes[i].Text))
                {
                    tv.SelectedNode = tv.Nodes[i];
                    tv.Focus();
                    tv.SelectedNode.Expand();
                    break;
                }
            }
        }

        private void ThumbnailViewer_MouseDoubleClick(object sender, EventArgs e, TreeView tv, DataGridView dgv)
        {
            string fileType = @"*.avi; *.mkv; *.mp4; *.mpg; *.wmv";

            Video video = new Video();
            //video.SearchVideoDrive(dgv, tv.SelectedNode.Text);
            if (fileType.Contains(Path.GetExtension(tv.SelectedNode.FirstNode.Text))) // click on video file
            {
                CallExecutable(@"PotPlayerMini64.exe", Path.Combine(SearchVideoDrive(dgv, tv.SelectedNode.Text), tv.SelectedNode.FirstNode.Text));
            }
            else
            {
                CallExecutable(@"PotPlayerMini64.exe", Path.Combine(SearchVideoDrive(dgv, tv.SelectedNode.Text), tv.SelectedNode.FirstNode.NextNode.Text));
            }
        }

        public Form f = new Form();
        PictureBox img = new PictureBox();

        private void ThumbnailViewer_MouseEnter(object sender, EventArgs e)
        {
            f.ShowInTaskbar = false;
            PictureBox clickedImage = (PictureBox)sender;
            f.Height = 536;
            f.Width = 800;
            f.FormBorderStyle = FormBorderStyle.None;
            img.Height = 536;
            img.Width = 800;
            //img.Image = Image.FromFile((string)clickedImage.Tag);

            // 2022/01/15: The image files can't be accessed by another process if using Image.FromFile 
            using (FileStream image = new FileStream((string)clickedImage.Tag, FileMode.Open))
            {
                img.Image = Image.FromStream(image);
            }

            new Cursor(Cursor.Current.Handle);

            if (Cursor.Position.X + 800 < 1920 && Cursor.Position.Y + 538 < 1080) //picture inside the screen?
            {
                f.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
            }
            else
            {
                f.Location = new Point(0, 0);
            }

            f.Controls.Add(img);
            f.Show();
        }

        private void ThumbnailViewer_MouseLeave(object sender, EventArgs e)
        {
            f.Hide();
        }
    }
}
