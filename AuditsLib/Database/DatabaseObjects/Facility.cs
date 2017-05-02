
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Facility
    {
        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public short fac_num { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string fac_str_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string fac_name { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte fac_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string fac_cn_str { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool fac_in_use { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual FacilityType FacilityType { get; set; }
    }
}
