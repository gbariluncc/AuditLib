using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IDCIssue : IDatabaseObject<DCIssue>
    {
        long DCIssueID { get; set; }
        byte FacilityTypeID { get; set; }
        DateTime AddDate { get; set; }
        int DCIssueVBU { get; set; }
        string DCIssueDescription { get; set; }
        string AuditorAction { get; set; }
        string FacilityInstructions { get; set; }
        string ActionPlan { get; set; }
        DateTime? GetWellDate { get; set; }
        string GetWellFolder { get; set; }
        string DCIssueFolder { get; set; }

        IFacilityType FacilityType { get; set; }
        ICollection<IDCIssueFacility> DCIssueFacilities { get; set; }
        ICollection<IDCIssueItem> DCIssueItems { get; set; }

        IDCIssue DCIssue { get; set; }
    }
}
