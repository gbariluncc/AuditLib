using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class HoldReasonMap : DatabaseObject<HoldReasonMap>, IHoldReasonMap
    {

        public int MapID
        {
            get
            {
                return map_id;
            }
            set
            {
                map_id = value;
            }
        }

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

        public byte SourceID
        {
            get
            {
                return source_id;
            }
            set
            {
                source_id = value;
            }
        }

        public bool IsSafety
        {
            get
            {
                return is_safety;
            }
            set
            {
                is_safety = value;
            }
        }

        IHoldReason IHoldReasonMap.HoldReason
        {
            get { return HoldReason; }
        }

        ISource IHoldReasonMap.Source
        {
            get { return Source; }
        }
    }
}
