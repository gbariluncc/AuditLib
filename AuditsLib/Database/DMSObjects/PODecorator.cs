using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using Audits.Infastructure;

namespace Audits.Database.DMSObjects
{
    public abstract class PODecorator : ViewBase, IPO
    {
        private IPO _po;
        //private HashSet<IRequestItem> _requestItems;

        public PODecorator(IPO po)
        {
            _po = po;
        }
        public IPO Root
        {
            get
            {
                return _po;
            }
        }
        public bool NeedsToSave
        {
            get { return _po.NeedsToSave; }
            set { _po.NeedsToSave = value; }
        }
        public void AddAsync(bool addAll = false, ProgressReporter pg = null)
        {
            _po.AddAsync(addAll,pg);
        }
        public DateTime ScheduledArrival
        {
            get { return _po.ScheduledArrival; }
            set { _po.ScheduledArrival = value; }
        }
        public int Facility
        {
            get { return _po.Facility; }
            set { _po.Facility = value; }
        }
        public long Number
        {
            get
            {
                return _po.Number;
            }
            set
            {
                _po.Number = value;
            }
        }

        public long RcvQty
        {
            get
            {
                return _po.RcvQty;
            }
            set
            {
                _po.RcvQty = value;
            }
        }

        public long OrdQty
        {
            get
            {
                return _po.OrdQty;
            }
            set
            {
                _po.OrdQty = value;
            }
        }

        public double PercentComplete
        {
            get
            {
                return _po.PercentComplete;
            }
            set
            {
                _po.PercentComplete = value;
            }
        }

        public int? Door
        {
            get
            {
                return _po.Door;
            }
            set
            {
                _po.Door = value;
            }
        }

        public int Zone
        {
            get
            {
                return _po.Zone;
            }
            set
            {
                _po.Zone = value;
            }
        }

        public DateTime? LandedDate
        {
            get
            {
                return _po.LandedDate;
            }
            set
            {
                _po.LandedDate = value;
            }
        }

        public byte StatusCode
        {
            get
            {
                return _po.StatusCode;
            }
            set
            {
                _po.StatusCode = value;
            }
        }

        public string Vendor
        {
            get
            {
                return _po.Vendor;
            }
            set
            {
                _po.Vendor = value;
            }
        }

        public DateTime CloseDate
        {
            get
            {
                return _po.CloseDate;
            }
            set
            {
                _po.CloseDate = value;
            }
        }

        public long ShipFromVBU
        {
            get
            {
                return _po.ShipFromVBU;
            }
            set
            {
                _po.ShipFromVBU = value;
            }
        }
        public static bool operator ==(PODecorator o1, PODecorator o2)
        {
            if (object.Equals(o1, o2))
            {
                return true;
            }

            if (object.ReferenceEquals(o1, null) || object.ReferenceEquals(o2, null)) return false;

            return o1.Number == o2.Number;
        }
        public static bool operator !=(PODecorator o1, PODecorator o2)
        {
            return !(o1 == o2);
        }
        public override bool Equals(object obj)
        {
            if (obj is IPO)
            {
                return (obj as IPO).Number == _po.Number;
            }
            return false;
        }


       /* public ICollection<IRequestItem> RequestItems
        {
            get
            {
                return _po.RequestItems;
            }
            set
            {
                _po.RequestItems = value;
            }
        }*/
        public void Refresh()
        {
            
        }
        public virtual void Update()
        {
            throw new NotImplementedException();
        }

        public virtual void Add(bool addAll = false, ProgressReporter pg = null)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete()
        {
            throw new NotImplementedException();
        }

        public DBObjectState ObjectState
        {
            get
            {
                return DBObjectState.StateObjectUnchanged; //throw new NotImplementedException();
            }
            set
            {
                //throw new NotImplementedException();
            }
        }


        public ICollection<IRequestItem> RequestItems
        {
            get { return _po.RequestItems; }
        }


        public IRequestItem RequestItem
        {
            get { return _po.RequestItem; }
        }


        public string SCAC
        {
            get
            {
                return _po.SCAC;
            }
            set
            {
                _po.SCAC = value;
            }
        }

        public string TrailerID
        {
            get
            {
                return _po.TrailerID;
            }
            set
            {
                _po.TrailerID = value;
            }
        }
    }
}
