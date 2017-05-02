using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class DCIssueFacility
    {
        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public long dc_iss_fac_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long dc_iss_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public short dc_iss_fac_num { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime dc_iss_fac_rpt_dt { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual DCIssue DCIssue { get; set; }
    }
}
