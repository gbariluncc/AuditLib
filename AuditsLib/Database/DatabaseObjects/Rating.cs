
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Rating
    {
        public Rating()
        {
            this.Audits = new HashSet<Audit>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte rating_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string rating_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string rating_sht_desc { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Audit> Audits { get; set; }
    }
}
