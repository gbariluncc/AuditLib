
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class FailType
    {
        public FailType()
        {
            this.FailedSamples = new HashSet<FailedSample>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte fail_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string fail_typ_desc { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<FailedSample> FailedSamples { get; set; }
    }
}
