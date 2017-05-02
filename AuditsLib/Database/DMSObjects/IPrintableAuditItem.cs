using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public interface IPrintableAuditItem : IRequestItem
    {
        long TotalOH { get; }
        DCLocation Forward { get; }
        ICollection<DCLocation> Reserves { get; }
    }
}
