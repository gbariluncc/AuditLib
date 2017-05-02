
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class PackagingLevel
    {
        public PackagingLevel()
        {
            this.Dimensions = new HashSet<Dimension>();
            this.Pictures = new HashSet<Picture>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte lvl_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string lvl_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string lvl_dms_prefix { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool lvl_dms_avail { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string lvl_alt_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool lvl_has_qty { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Dimension> Dimensions { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
