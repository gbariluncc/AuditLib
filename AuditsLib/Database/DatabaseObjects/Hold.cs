using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Hold
    {
        public int hold_id { get; set; }
        public DateTime hold_dt { get; set; }
        public DateTime hold_rel_dt { get; set; }
        public int hold_po { get; set; }
        public byte reason_cd { get; set; }
        public string hold_comments { get; set; }
        public DateTime hold_expire { get; set; }

        public HoldReason HoldReason
        {
            get
            {
                return new HoldReason().Where("reason_cd={0}".Format(reason_cd)).FirstOrDefault();
            }
        }
    }
}
