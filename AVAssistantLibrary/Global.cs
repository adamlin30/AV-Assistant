using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace AVAssistantLibrary
{
    public class Global
    {
        // https://www.c-sharpcorner.com/blogs/how-make-global-variable-in-c-sharp
        public static DataTable DtVideoCollection = new DataTable();

        public static void ScanDrive(string [] drives)
        {
            if (DtVideoCollection.Rows.Count == 0) // Datatable is empty, start a new datatable
            {
                DtVideoCollection.Columns.Add("Drive"); // E:\
                DtVideoCollection.Columns.Add("Video"); // AAA-111 - Julia
                DtVideoCollection.Columns.Add("Full Path"); // E:\AAA-111 - Julia
                DtVideoCollection.Columns.Add("Creation Time"); // Timestamp when video created
                DtVideoCollection.Columns.Add("Video ID"); // AAA-111
                DtVideoCollection.Columns.Add("Actress"); // Julia
                DtVideoCollection.Columns.Add("Genre"); // Best
            }

            DtVideoCollection.Clear();

            foreach (var d in drives)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                DirectoryInfo[] subDirs = di.GetDirectories();

                foreach (DirectoryInfo s in subDirs)
                {
                    if (Regex.Match(s.Name, @"^\w+-\d+\w? - \w+$|^\w+-\d+\w?$").Success)
                    // Search folders format: AAA-111 - Julia or AAA-111
                    {
                        string[] items = {s.Root.ToString(), s.Name, s.FullName, s.CreationTime.ToString("yyyy/MM/dd/ hh:mm:ss")};
                        string[] video = s.Name.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                        // Somethimes it returns one value when the folder has no actress name                      
                        items = items.Concat(video).ToArray();

                        if (video.Length == 1)
                        {
                            string[] genre = {"","NA"};
                            items = items.Concat(genre).ToArray();
                        }
                        else
                        {
                            string[] genre = {"NA"};
                            items = items.Concat(genre).ToArray();
                        }
                        
                        DtVideoCollection.Rows.Add(items);
                    }
                }
            }
        }
    }
}
