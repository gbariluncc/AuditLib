using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IAuditor : IDatabaseObject<Auditor>
    {
        int UserID { get; set; }
        bool GetsFailedSamples { get; set; }

        IUser User { get; set; }

        IAuditor Auditor { get; set; }
    }
}
