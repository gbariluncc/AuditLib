using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IDCIssueItem : IDatabaseObject<DCIssueItem>
    {
        long DCIssueItemID { get; set; }
        long DCIssueID { get; set; }
        long ItemNumber { get; set; }

        IDCIssue DCIssue { get; set; }

        IDCIssueItem DCIssueItem { get; set; }
    }
}
