using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Audits.Database.DataAccessLayer;
using Audits.Database;
using System.Reflection;

namespace Audits.Helpers
{
    public static class DocFolderHelper
    {
        private static string BASE_DIR = "\\\\msfs05.lowes.com\\data1\\Share\\Lognet\\Sample Room\\SampleRoomAudits\\bin\\AuditData";
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }

        }

        public static void MakeFolder(IRequest request, out string path)
        {
            if (string.IsNullOrEmpty(request.DocumentFolder))
            {
                MakeDocFolder(request, out path);
            }
            else
            {
                path = request.DocumentFolder;
            }
        }
        public static void MakeFolder(string path)
        {
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(path + "\\Documents");
        }
        private static bool MakeDocFolder(IRequest request, out string path)
        {
            try
            {
                Random r = new Random();
                long tim = (long)(new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds);
                bool needsToClose = false;

                path = BASE_DIR + "\\" + tim.ToString() + "_" + r.Next(1, 2000).ToString();

                //Find a better place to hold sub folder names
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "\\Documents");
                Directory.CreateDirectory(path + "\\Pics");

                request.DocumentFolder = path;
                request.UpdateDate = DateTime.Now;;

                request.Update();

                return true;
            }
            catch { path = string.Empty; return false; }
        }
    }
}
