﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace AVAssistantLibrary
{
    public class Video
    {
        public string[] drives { get; set; }
        public string sortBy = "Creation Time DESC";
        FileUtility fileUtility = new FileUtility();
        public List<string> videoListBoxItems = new List<string>();

        public void ListVideo(ListBox lb, DataGridView dgv, TextBox tb)
        {
            lb.Items.Clear();

            //form.videoFileTreeView.Nodes.Clear();
            //form.coverPictureBox.Image = null;

            DataTable dtVideo = new DataTable();
            dtVideo.Columns.Add("Drive");
            dtVideo.Columns.Add("Video");
            dtVideo.Columns.Add("Creation Time");

            foreach (var d in drives)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                DirectoryInfo[] subDirs = di.GetDirectories();

                foreach (DirectoryInfo s in subDirs)
                {
                    if (Regex.Match(s.Name, @"^\w+-\d+\w? - \w+$|^\w+-\d+\w?$").Success)
                    //search folders matching AAA-111 - Julia or AAA-111
                    {
                        string[] items = { s.Root.ToString(), s.Name, s.CreationTime.ToString("yyyy/MM/dd/ hh:mm:ss") };
                        dtVideo.Rows.Add(items);
                    }
                }
            }

            dgv.DataSource = dtVideo;
            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].Width = 200;

            dtVideo.DefaultView.Sort = sortBy;
            dtVideo = dtVideo.DefaultView.ToTable();

            for (int i = 0; i < dtVideo.Rows.Count; i++)
            {
                lb.Items.Add(dtVideo.Rows[i]["Video"].ToString()); //insert video to listbox
            }

            videoListBoxItems = lb.Items.Cast<String>().ToList(); //https://stackoverflow.com/questions/1565504/most-succinct-way-to-convert-listbox-items-to-a-generic-list

            tb.Text = dtVideo.Rows.Count.ToString();
        }

        public void ListGenre(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            dt = fileUtility.ReadCSV(@"E:\temp\test.csv"); //read csv file
            dgv.DataSource = dt;

            dgv.Columns[0].Width = 200;
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 65;
            }
        }

    }
}
