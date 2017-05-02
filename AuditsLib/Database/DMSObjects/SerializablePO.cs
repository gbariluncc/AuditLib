using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    [Serializable]
    public class SerializablePO : IEquatable<SerializablePO>
    {
        public long Number { get; set; }
        public static bool operator ==(SerializablePO obj1, SerializablePO obj2)
        {
            if (((object)obj1) == null && ((object)obj2) == null) return true;
            if (((object)obj1) == null || ((object)obj2) == null) return false;
            return obj1.Number == obj2.Number;
        }
        public static bool operator !=(SerializablePO obj1, SerializablePO obj2)
        {
            return !(obj1 == obj2);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (obj is SerializablePO)
            {
                return this == (SerializablePO)obj;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public bool Equals(SerializablePO other)
        {
            return this == other;
        }
    }
}
