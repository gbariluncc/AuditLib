using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class HoldReason
    {
        public byte reason_cd { get; set; }
        public string reason_txt { get; set; }

        public ICollection<Hold> Holds
        {
            get
            {
                return new Hold().Where("reason_cd={0}".Format(reason_cd));
            }
        }
    }
}
