

namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class FailedSample
    {
        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public int itm_num { get; set; }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public int po_num { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime sample_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int vbu { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string fail_sum { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string gen_comm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte fail_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool is_new { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime expire_date { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte sts_cd { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime add_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime fs_upd_dm { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual FailType FailType { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual Status Status { get; set; }
    }
}
