using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IDCIssueFacility : IDatabaseObject<DCIssueFacility>
    {
        long DCIssueFacilityID { get; set; }
        long DCIssueID { get; set; }
        short FacilityNumber { get; set; }
        DateTime ReportDate { get; set; }

        IDCIssue DCIssue { get; set; }

        IDCIssueFacility DCIssueFacility { get; set; }
    }
}
