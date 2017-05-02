using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public class DCLocation 
    {
        private string _location;

        public DCLocation(string location)
        {
            _location = location;
        }
        public int QtyOH { get; set; }

        public short Aisle
        {
            get
            {
                return short.Parse(_location.Substring(0, 4));
            }
        }
        public string Bay
        {
            get { return _location.Substring(4, 2); }
        }
        public string Level
        {
            get { return _location.Substring(6, 2); }
        }
        public string Position
        {
            get { return _location.Substring(8, 2); }
        }
        public string Trail
        {
            get { return _location.Substring(10, 2); }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public byte StorageFunction
        {
            get;
            set;
        }
        public short PickZone { get; set; }

        public string LocationType
        {
            get
            {
                if (StorageFunction == 10) { return "Forward"; }
                else if (StorageFunction == 90) { return "Reserve"; }
                else { return "Other"; }
            }
        }
        public string DisplayLocation
        {
            get
            {
                if (_location == string.Empty)
                {
                    return "No Available Location.";
                }
                else
                {
                    return _location.Substring(0, 4) +
                        "-" + _location.Substring(4, 2) +
                        "-" + _location.Substring(6, 2) +
                        "-" + _location.Substring(8, 2) +
                        "-" + _location.Substring(10, 2);
                }
            }
        }
    }
}
