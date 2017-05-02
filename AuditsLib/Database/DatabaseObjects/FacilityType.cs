using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class FacilityType
    {
        public FacilityType()
        {
            this.DCIssues = new HashSet<DCIssue>();
            this.Facilities = new HashSet<Facility>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte fac_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string fac_typ_desc { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<DCIssue> DCIssues { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
