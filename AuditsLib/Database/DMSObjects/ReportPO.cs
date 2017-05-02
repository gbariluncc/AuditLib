using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public class ReportPO
    {
        private IPOWithStatus _po;

        public ReportPO(IPOWithStatus po)
        {
            _po = po;
        }
        public string Number
        {
            get
            {
                return _po.Number.ToString();
            }
        }
        public string Vendor
        {
            get
            {
                return _po.Vendor;
            }
        }
        public string VBU
        {
            get
            {
                return _po.ShipFromVBU.ToString();
            }
        }
        public string ExpectedArrival
        {
            get
            {
                return _po.ScheduledArrival.ToShortDateString();
            }
        }
        public string LandedDate
        {
            get
            {
                return _po.LandedDate == null? string.Empty : _po.LandedDate.Value.ToShortDateString();
            }
        }
        public string SCAC
        {
            get
            {
                return string.Empty;
            }
        }
        public string TrailerID
        {
            get { return string.Empty; }
        }
        public string Reason
        {
            get;
            set;
        }
    }
}
