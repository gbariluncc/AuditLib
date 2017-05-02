using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Audits.Database.DMSObjects
{
    [Serializable]
    public class POList : HashSet<SerializablePO>
    {
        public POList() { }

        public void AddPO(IPOWithStatus po)
        {
            this.Add(po);
        }
        public void AddPO(IPO po)
        {
            SerializablePO temp = new SerializablePO() { Number = po.Number };
            this.AddPO(temp);
        }
        public void AddPO(SerializablePO po)
        {
            this.Add(po);
        }

        internal void Add(IPO po)
        {
            this.Add(po);
        }
    }
}
