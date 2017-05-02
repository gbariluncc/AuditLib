using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Threading;
using Audits.Database.DMSObjects;
using Audits.Database;
using Audits.Database.DatabaseObjects;
using System.Windows;

namespace Audits.Services
{
    public class POService : Service<POWithStatus>
    {
        private const string FILE_NAME = "POWatchList.xml";
        private HashSet<POWithStatus> _manualCol;
        private POList _manualList;

        public POService()
        {
            _manualList = new POList();
            _manualCol = new HashSet<POWithStatus>();
           LoadPOList();
           InternalData = GetPOList();
           SetGetDataAction(() => GetPOList());

        }
        public void AddPO(long number)
        {
            _manualList.Add(new SerializablePO() { Number = number });
            _manualCol.Add(new POWithStatus(number));
            InternalData.Add(new POWithStatus(number));
        }
        public void RemovePO(POWithStatus po)
        {
            SerializablePO spo = _manualList.FirstOrDefault(p => p.Number == po.Number);
            
            if (spo != null && po != null)
            {
                lock (InternalData)
                {
                    _manualCol.Remove(po);
                    _manualList.Remove(spo);
                    InternalData.Remove(po);
                }
            }
        }
        public void RemovePO(long poNum)
        {
            POWithStatus po = _manualCol.FirstOrDefault(p => p.Number == poNum);

            this.RemovePO(po);
        }
        private ICollection<POWithStatus> GetPOList()
        {
            HashSet<POWithStatus> temp = new HashSet<POWithStatus>();

            temp.UnionWith(_manualCol);
            temp.UnionWith(ProcessTasks());

            return temp;
        }
        private void LoadPOList()
        {
            _manualList = new POList();
            if (File.Exists(FILE_NAME))
            {
                using (var stream = File.OpenRead(FILE_NAME))
                {
                    var serializer = new XmlSerializer(typeof(POList));
                    _manualList = serializer.Deserialize(stream) as POList;
                    _manualList.Each(p => _manualCol.Add(new POWithStatus(p.Number)));
                }
            }
        }

        private HashSet<POWithStatus> ProcessTasks()
        {
            HashSet<POWithStatus> taskPOs = new HashSet<POWithStatus>();
            ICollection<ITask> tasks = AppServices.TaskService.InternalData;

            lock (taskPOs)
            {
                tasks.Each(t =>
                {
                    t.Request.RequestItems.Each(r =>
                    {
                        if (r.StatusCode == 2)
                        {
                            if (r.ItemTypeID == 2)
                            {
                                taskPOs.Add(new POWithStatus(r));
                            }
                            else if (r.ContainerType == 1)
                            {
                                r.Children.Each(c =>
                                {
                                    if (c.StatusCode == 2)
                                        taskPOs.Add(new POWithStatus(c));
                                });
                            }
                        }
                    });
                });
            }
            return taskPOs;
        }

        private void SerializeList()
        {
            try
            {
                using (var stream = File.Open(FILE_NAME, FileMode.Create))
                {
                    var serializer = new XmlSerializer(typeof(POList));
                    serializer.Serialize(stream, _manualList);
                }

            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
        ~POService()
        {
            SerializeList();
        }
    }
}
