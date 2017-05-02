using System;
using System.Collections.Generic;


namespace Audits.Database.DatabaseObjects
{
    public partial class Dimension
    {
        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long dim_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long req_itm_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte lvl_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public double dim_len { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public double dim_wid { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public double dim_hgt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public double dim_wgt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int dim_qty { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime dim_add_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte cat_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int usr_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int dim_stk_hgt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public double dim_pkg_wgt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string dim_comm { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual Category Category { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual PackagingLevel PackagingLevel { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual RequestItem RequestItem { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual User User { get; set; }
    }
}
