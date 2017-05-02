using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public interface IPO : IDMSObject<PO>
    {
        long Number { get; set; }
        long RcvQty { get; set; }
        long OrdQty { get; set; }
        double PercentComplete { get; set; }
        int? Door { get; set; }
        int Zone { get; set; }
        DateTime? LandedDate { get; set; }
        byte StatusCode { get; set; }
        string Vendor { get; set; }
        DateTime CloseDate { get; set; }
        long ShipFromVBU { get; set; }
        int Facility { get; set; }
        DateTime ScheduledArrival { get; set; }
        string SCAC { get; set; }
        string TrailerID { get; set; }

        ICollection<IRequestItem> RequestItems { get; }
        IRequestItem RequestItem { get; }
    }
}
