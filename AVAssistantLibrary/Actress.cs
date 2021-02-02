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
    public class Actress
    {
        public string[] drives { get; set; }
        public string[] actressNameFromFolderArr = { };
        FileUtility fileUtility = new FileUtility();
        
        public void ListActress(ListBox lb, DataGridView dgv)
        {
            //actress sources from the CSV and the folders
            var actressNameInFile = new List<string>();
            var actressNameFromFolder = new List<string>();
            var actressScore = new List<string>();
            DataTable dtActressInFile = new DataTable();

            dtActressInFile = fileUtility.ReadCSV(@"E:\temp\AV_Actress_C.csv");
            //read csv file, source 1: CSV

            for (int i = 0; i < dtActressInFile.Rows.Count; i++)
            {
                actressNameInFile.Add(dtActressInFile.Rows[i][0].ToString());
                actressScore.Add(dtActressInFile.Rows[i][1].ToString());
            }

            string[] actressNameInFileArr = actressNameInFile.ToArray(); //actress names in csv file


            foreach (var d in drives)
            {
                string[] subDirs = Directory.GetDirectories(d, @"* - *");

                foreach (string s in subDirs) //search actress names from folders, source 2: folders
                {
                    string videoID = s.Substring(0, s.IndexOf(" - ")).Trim(); //AAA-111
                    string actressName = s.Substring(s.IndexOf(" - ") + 2).Trim(); //Julia

                    if (!String.IsNullOrEmpty(actressName)) //if actress name is not empty string
                    {
                        actressNameInFile.Add(actressName); //actress in CSV + actress from folder
                        actressNameFromFolder.Add(actressName); //actress from folder only
                    }
                }
            }

            actressNameFromFolderArr = actressNameFromFolder.Distinct().ToArray();
            Array.Sort(actressNameFromFolderArr);

            foreach (string i in actressNameFromFolderArr)
            {
                lb.Items.Add(i); //insert actress name to listbox
            }

            string[] actressNameAllArr = actressNameInFile.Distinct().ToArray(); //actress in CSV + actress from folder
            Array.Sort(actressNameAllArr);

            string[] item = new string[2];
            DataTable dtActress = new DataTable();
            dtActress.Columns.Add("Actress Name");
            dtActress.Columns.Add("Actress Score");

            for (int i = 0; i < actressNameAllArr.Length; i++)
            {
                if (!actressNameInFileArr.Contains(actressNameAllArr[i]))
                {
                    actressScore.Insert(i, "0"); //if actress is not evalauted in csv, set 0 point
                }
                item[0] = actressNameAllArr[i];
                item[1] = actressScore[i];
                dtActress.Rows.Add(item);
            }
            dgv.DataSource = dtActress;
            dgv.Columns[0].Width = 200;
            dgv.Columns[1].Width = 200;
        }

    }
}
