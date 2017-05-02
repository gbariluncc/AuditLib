using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database.DMSObjects
{
    public partial class PO : IPO
    {
        private HashSet<IRequestItem> _requestItems;

        public long Number
        {
            get
            {
                return po_num;
            }
            set
            {
                po_num = value;
            }
        }
        public DateTime ScheduledArrival
        {
            get { return shd_arv_dm; }
            set { shd_arv_dm = value; OnPropertyChanged(); }
        }
        public double PercentComplete
        {
            get
            {
                return (double)RcvQty / OrdQty;
            }
            set
            {
                PerComp = value;
            }
        }
        public int? Door
        {
            get
            {
                if (DoorNum <= 1 && DoorNum >= -1)
                {
                    return (int?)null;
                }
                else { return DoorNum; }
            }
            set { DoorNum = value.Value; }
        }
        public DateTime? LandedDate
        {
            get
            {
                return Landed == DateTime.Parse("1/1/1900")? (DateTime?)null : Landed;
            }
            set
            {
                Landed = value == null ? DateTime.Parse("1/1/1900") : value.Value;
            }
        }

        public long ShipFromVBU
        {
            get
            {
                long outVal;
                bool res = long.TryParse(VendorNum, out outVal);
                return res == true ? outVal : 0;
            }
            set
            {
                VendorNum = value.ToString();
            }
        }
        public static bool operator ==(PO o1, PO o2)
        {
            if (object.Equals(o1, o2))
            {
                return true;
            }

            if (object.ReferenceEquals(o1, null) || object.ReferenceEquals(o2, null)) return false;

            return o1.Number == o2.Number;
        }
        public static bool operator !=(PO o1, PO o2)
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
       /* public ICollection<IRequestItem> RequestItems
        {
            get
            {
                if (_requestItems == null)
                {
                    _requestItems = new RequestItem().Where("req_itm_val=" + Number).ToHashSet<IRequestItem>();
                }
                return _requestItems;
            }
            set
            {
                _requestItems = (HashSet<IRequestItem>)value;
            }
        }*/


        public ICollection<IRequestItem> RequestItems
        {
            get
            {
                return new RequestItem().Where("req_itm_val={0}".Format(Number)).ToHashSet<IRequestItem>();
            }
        }


        public string SCAC
        {
            get
            {
                return san_cai_acs_id;
            }
            set
            {
                san_cai_acs_id = value;
            }
        }

        public string TrailerID
        {
            get
            {
                return cai_trl_id;
            }
            set
            {
                cai_trl_id = value;
            }
        }
    }
}
