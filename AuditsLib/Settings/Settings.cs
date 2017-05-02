using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Audits.Settings
{
    public class Settings
    {
        private static POStatusSettings _poSettings;

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }
        public static POStatusSettings POStatusSettings
        {
            get
            {
                if (_poSettings == null)
                {
                    GetPOSettings();
                }
                return _poSettings;
            }
        }
        public static void SavePOSettings()
        {
            string path = AssemblyDirectory + "\\POStatusSettings.xml";
            using (var stream = File.Open(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(POStatusSettings));
                serializer.Serialize(stream, _poSettings);
            }

        }
        public static void GetPOSettings()
        {
            try
            {
                    string path = AssemblyDirectory + "\\POStatusSettings.xml";
                    if (File.Exists(path))
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            var serializer = new XmlSerializer(typeof(POStatusSettings));
                            _poSettings = serializer.Deserialize(stream) as POStatusSettings;
                        }
                    }
                    else
                    {
                        _poSettings = new POStatusSettings(true);
                    }
                
            }
            catch { _poSettings = new POStatusSettings(true); }
        }
    }
}
