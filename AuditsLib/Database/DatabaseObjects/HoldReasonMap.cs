using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class HoldReasonMap
    {
        public int map_id { get; set; }
        public byte reason_cd { get; set; }
        public byte source_id { get; set; }
        public bool is_safety { get; set; }

        public Source Source
        {
            get { return new Source().Where("source_id={0}".Format(source_id)).FirstOrDefault(); }
        }
        public HoldReason HoldReason
        {
            get { return new HoldReason().Where("reason_cd={0}".Format(reason_cd)).FirstOrDefault(); }
        }
    }
}
