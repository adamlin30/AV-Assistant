using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AVAssistantLibrary
{
    public class FolderUtility
    {
        public string LocateVideoFolder(DataGridView dgv, string selectedVideo) // same as SearchVideoDrive
        {
            DataTable dt = (DataTable)(dgv.DataSource); //datasource to datatable
            DataRow[] dr = dt.Select("Video = '" + selectedVideo + "'");
            int index = dt.Rows.IndexOf(dr[0]);

            return Path.Combine(dt.Rows[index]["Drive"].ToString(), selectedVideo);
        }

        public void DeleteDirectory(string path, bool recursive)
        {
            if (recursive)
            {
                var subfolders = Directory.GetDirectories(path);
                foreach (var s in subfolders)
                {
                    DeleteDirectory(s, recursive);
                }
            }
            var files = Directory.GetFiles(path);
            foreach (var f in files)
            {
                var attr = File.GetAttributes(f);
                if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    File.SetAttributes(f, attr ^ FileAttributes.ReadOnly);
                }
                File.Delete(f);
            }

            // At this point, all the files and sub-folders have been deleted.
            // So we delete the empty folder using the OOTB Directory.Delete method.
            Directory.Delete(path);
        }
    }
}
