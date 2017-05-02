using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IHoldReasonMap : IDatabaseObject<HoldReasonMap>
    {
        int MapID { get; set; }
        byte ReasonCode { get; set; }
        byte SourceID { get; set; }
        bool IsSafety { get; set; }

        IHoldReason HoldReason { get; }
        ISource Source { get; }
    }
}
