using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IAudit : IDatabaseObject<Audit>
    {
        long AuditID { get; set; }
        long RequestItemID { get; set; }
        byte CategoryID { get; set; }
        byte RatingID { get; set; }
        string AuditComments { get; set; }
        DateTime AuditDate { get; set; }
        int UserID { get; set; }

        ICategory Category { get; set; }
        IRating Rating { get; set; }
        IRequestItem RequestItem { get; set; }
        IUser User { get; set; }

        IAudit Audit { get; set; }
    }
}
