using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Audits.Database.DMSObjects
{
    public class POListHelper
    {
        private static POListHelper _instance;
        private POList _poList;

        private POListHelper()
        {

        }
        public static POListHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new POListHelper();
                }
                return _instance;
            }
        }
        public POList POList
        {
            get { return _poList; }
        }
        public POListHelper GetPOList()
        {
            try
            {
                if (_poList == null)
                {
                    string path = Settings.Settings.AssemblyDirectory + "\\POList.xml";
                    if (File.Exists(path))
                    {
                        using (var stream = File.OpenRead(path))
                        {
                            var serializer = new XmlSerializer(typeof(POList));
                            _poList = serializer.Deserialize(stream) as POList;
                        }
                    }
                    else
                    {
                        _poList = new POList();
                    }
                }
            }
            catch { _poList = new POList(); }
            return this;
        }
        public void SavePOList()
        {
            string path = Settings.Settings.AssemblyDirectory;

            using (var stream = File.Open(path + "\\POList.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(POList));
                serializer.Serialize(stream, _poList);
            }
        }
    }
}
