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
    }
}
