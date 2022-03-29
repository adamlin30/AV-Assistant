using System;
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
        public string SortBy = "Creation Time DESC";
        public List<string> VideoListBoxItems = new List<string>();
        FileUtility fileUtility = new FileUtility();

        // Everything about Video is now stored in the DtVideoCollection
        public void UpdateVideo(ListBox lb, DataGridView dgv, TextBox tb)
        {
            dgv.DataSource = Global.DtVideoCollection;
            dgv.Columns[0].Width = 20;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 100;
            dgv.Columns[4].Width = 100;
            dgv.Columns[5].Width = 100;
            dgv.Columns[6].Width = 100;

            lb.Items.Clear();

            // Sort the table
            Global.DtVideoCollection.DefaultView.Sort = SortBy;
            Global.DtVideoCollection = Global.DtVideoCollection.DefaultView.ToTable();

            for (int i = 0; i < Global.DtVideoCollection.Rows.Count; i++)
            {
                lb.Items.Add(Global.DtVideoCollection.Rows[i]["Video"].ToString()); // Add videos to listbox
            }

            // Filter text changed 
            VideoListBoxItems = lb.Items.Cast<String>().ToList(); // https://stackoverflow.com/questions/1565504/most-succinct-way-to-convert-listbox-items-to-a-generic-list

            tb.Text = Global.DtVideoCollection.Rows.Count.ToString();
        }

        public void ListGenre(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            dt = fileUtility.ReadCSV(@"E:\temp\test.csv"); // Read CSV file
            dgv.DataSource = dt;

            dgv.Columns[0].Width = 200;
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 65;
            }
        }

    }
}
