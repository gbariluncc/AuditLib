using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Audits.Database.DMSObjects
{
    public interface IHoldPO: IPO, IPOWithStatus, IHold
    {
        bool IsSelected { get; set; }
        string RequestTitle { get; }
        string AuditType { get; }
        IHold Hold { get; set; }

        ICommand OpenAudit { get; set; }
    }
}
