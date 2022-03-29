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
        public string[] ActressNameFromFolderArr = { };
        FileUtility fileUtility = new FileUtility();

        public void UpdateActress(ListBox lb, DataGridView dgv, ToolStripComboBox cb)
        {
            // Actress names should be gathered from the CSV and the video folders
            var actressNameInFile = new List<string>();
            var actressNameFromFolder = new List<string>();
            var actressScore = new List<string>();
            DataTable dtActressInFile = new DataTable();

            cb.Items.Clear();

            // Read CSV file (source 1)
            dtActressInFile = fileUtility.ReadCSV(@"E:\temp\AV_Actress_C.csv");

            for (int i = 0; i < dtActressInFile.Rows.Count; i++)
            {
                actressNameInFile.Add(dtActressInFile.Rows[i][0].ToString());
                actressScore.Add(dtActressInFile.Rows[i][1].ToString());
            }

            // Get actress names from CSV file and put them in an array
            string[] actressNameInFileArr = actressNameInFile.ToArray();

            // Get folder data from Global class, no need to scan drives again (source 2)
            for (int i = 0; i < Global.DtVideoCollection.Rows.Count; i++)
            {
                string actressName = Global.DtVideoCollection.Rows[i]["Actress"].ToString();
                if (!String.IsNullOrEmpty(actressName)) // If actress name is not an empty string
                {
                    actressNameInFile.Add(actressName); // Actress in CSV + actress from folder
                    actressNameFromFolder.Add(actressName); // Actress from folder only
                }               
            }

            ActressNameFromFolderArr = actressNameFromFolder.Distinct().ToArray();
            Array.Sort(ActressNameFromFolderArr);

            cb.Text = "--Select Actress--"; // For rename combo box
            cb.Items.Add("NEW NAME");

            foreach (string i in ActressNameFromFolderArr)
            {
                lb.Items.Add(i); // Insert actress name to listbox
                //https://social.msdn.microsoft.com/Forums/windows/en-US/8d02a333-35e3-4705-a71e-4c0598395f04/insert-subitem-to-items-from-contextmenustrip-in-runtime-and-access-to-subitems?forum=winforms
                //((ToolStripMenuItem)cms.Items[5]).DropDownItems.Add(i); // insert actress names to context menu
                cb.Items.Add(i);
            }

            string[] actressNameAllArr = actressNameInFile.Distinct().ToArray(); // Actress in CSV and actress from folders
            Array.Sort(actressNameAllArr);

            string[] items = new string[2];
            DataTable dtActressCollection = new DataTable();
            dtActressCollection.Columns.Add("Actress Name");
            dtActressCollection.Columns.Add("Actress Score");

            
            for (int i = 0; i < actressNameAllArr.Length; i++)
            {
                // If an actress is not listed in CSV, set -1 point
                if (!actressNameInFileArr.Contains(actressNameAllArr[i]))
                {
                    actressScore.Insert(i, "-1");
                }
                items[0] = actressNameAllArr[i];
                items[1] = actressScore[i];
                dtActressCollection.Rows.Add(items);
            }

            dgv.DataSource = dtActressCollection; // Update actressDataGridView
            dgv.Columns[0].Width = 200;
            dgv.Columns[1].Width = 200;
        }
    }
}
