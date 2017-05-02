using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class HoldReason : DatabaseObject<HoldReason>, IHoldReason
    {
        public byte ReasonCode
        {
            get
            {
                return reason_cd;
            }
            set
            {
                reason_cd = value;
            }
        }

        public string ReasonText
        {
            get
            {
                return reason_txt;
            }
            set
            {
                reason_txt = value;
            }
        }

        ICollection<IHold> IHoldReason.Holds
        {
            get { return Holds.ToHashSet<IHold>(); }
        }
    }
}
