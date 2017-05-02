using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Hold : DatabaseObject<Hold>, IHold
    {
        public int HoldID
        {
            get
            {
                return hold_id;
            }
            set
            {
                hold_id = value;
            }
        }

        public DateTime HoldDate
        {
            get
            {
                return hold_dt;
            }
            set
            {
                hold_dt = value;
            }
        }

        public DateTime ReleaseDate
        {
            get
            {
                return hold_rel_dt;
            }
            set
            {
                hold_rel_dt = value;
            }
        }

        public int PONumber
        {
            get
            {
                return hold_po;
            }
            set
            {
                hold_po = value;
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

        public string HoldComments
        {
            get
            {
                return hold_comments;
            }
            set
            {
                hold_comments = value;
            }
        }

        public DateTime HoldExpiration
        {
            get
            {
                return hold_expire;
            }
            set
            {
                hold_expire = value;
            }
        }

        IHoldReason IHold.HoldReason
        {
            get { return HoldReason; }
        }
    }
}
