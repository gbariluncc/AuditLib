using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public class POwithItemCombo : PODecorator
    {
        private List<long> _items;

        /*public POwithItemCombo(long number)
            : base(new PO(number))
        {
            _items = new List<long>();
        }*/
        public POwithItemCombo(IPO po)
            : base(po)
        {
            _items = new List<long>();
        }
        public IList<long> ItemCombos
        {
            get { return _items; }
            set { _items = (List<long>)value; }
        }
        public string ItemCombosString
        {
            get
            {
                string ret = string.Empty;
                _items.ForEach(i => ret += i.ToString() + ",");

                return ret.Substring(0, ret.Length - 1);
            }
        }
        public static bool operator ==(POwithItemCombo o1, POwithItemCombo o2)
        {
            if (object.Equals(o1, o2))
            {
                return true;
            }

            if (object.ReferenceEquals(o1, null) || object.ReferenceEquals(o2, null)) return false;

            return o1.Number == o2.Number;
        }
        public static bool operator !=(POwithItemCombo o1, POwithItemCombo o2)
        {
            return !(o1 == o2);
        }
        public override bool Equals(object obj)
        {
            if (obj is IPO)
            {
                return (obj as IPO).Number == this.Number;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
