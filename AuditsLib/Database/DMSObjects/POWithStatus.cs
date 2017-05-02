using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public class POWithStatus : PODecorator, IPOWithStatus, IEquatable<POWithStatus>
    {
        private string _statusDesc;

        public POWithStatus(IPO po)
            : base(po)
        {
            LocationStatus = GetStatusString();
        }
        public POWithStatus(long number)
            : base(new PO(number))
        {
            LocationStatus = GetStatusString();
        }
        public POEntryType POEntryType { get; set; }

        public POWithStatus() : base(new PO())
        {
            // TODO: Complete member initialization
            LocationStatus = GetStatusString();
        }
        public POWithStatus(IRequestItem requestItem)
            : base(new PO(requestItem))
        {
            LocationStatus = GetStatusString();
        }
        public POLocationStatus LocationStatusCode { get; set; }
        public string LocationStatus
        {
            get
            {
                return _statusDesc;
            }
            set
            {
                _statusDesc = value;
            }
        }

        public void RefreshStatus()
        {
            if (DMSConnection.GetInstance().Connection == null) return;

            POWithStatus temp = new POWithStatus(this);

            if (temp.LocationStatusCode != this.LocationStatusCode || temp.RcvQty != this.RcvQty)
            {
                this.Copy(temp);
            }
        }
        public static bool operator ==(POWithStatus obj1, POWithStatus obj2)
        {
            if (object.ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (object.ReferenceEquals(obj1, null) ||
                object.ReferenceEquals(obj2, null))
            {
                return false;
            }
            return obj1.Number == obj2.Number;
        }
        public static bool operator !=(POWithStatus obj1, POWithStatus obj2)
        {
            return !(obj2 == obj1);
        }
        public override bool Equals(object obj)
        {
            if (obj is POWithStatus)
            {
                return (obj as POWithStatus) == this;
            }
            return false;
        }
        private string GetStatusString()
        {
            if (StatusCode == 4) { LocationStatusCode = POLocationStatus.Hold; return "On Hold"; }
            if (StatusCode == 8 || StatusCode == 6) { LocationStatusCode = POLocationStatus.Closed; return "Closed"; }
            if (StatusCode == 0 && (LandedDate.Equals(new DateTime(1900, 1, 1)) || LandedDate == null))
            {
                LocationStatusCode = POLocationStatus.Unavailable;
                Door = -1;
                return "Not Arrived";
            }
            if (StatusCode == 0 && !LandedDate.Equals(null))
            {
                switch (Zone)
                {
                    case 10:
                    case 15:
                    case 55:
                    case 35:
                        LocationStatusCode = POLocationStatus.Yard;
                        return "On Yard";

                    case 20:
                    case 21:
                        LocationStatusCode = POLocationStatus.Doors;
                        return "In Doors";

                    default:
                        LocationStatusCode = POLocationStatus.Unavailable;
                        Door = -1;
                        return "Unavailable";
                }
            }

            if (StatusCode == 14 && !LandedDate.Equals(null))
            {
                switch (Zone)
                {
                    case 10:
                    case 15:
                        LocationStatusCode = POLocationStatus.Received;
                        return "Received";

                    case 20:
                    case 21:
                        LocationStatusCode = POLocationStatus.Receiving;
                        return "In Receiving";

                    default:
                        LocationStatusCode = POLocationStatus.Received;
                        return "Received";
                }
            }
            LocationStatusCode = POLocationStatus.Unavailable;
            Door = -1;
            return "Unable to determine";
        }

        public bool Equals(POWithStatus other)
        {
            return this == other;
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
    [Serializable]
    public enum POLocationStatus
    {
        Unavailable,
        Yard,
        Doors,
        Receiving,
        Received,
        Closed,
        Hold, 
        NotArrived
    }
}
