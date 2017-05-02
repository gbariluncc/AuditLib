using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IHoldReason : IDatabaseObject<HoldReason>
    {
        byte ReasonCode { get; set; }
        string ReasonText { get; set; }

        ICollection<IHold> Holds { get; }
    }
}
