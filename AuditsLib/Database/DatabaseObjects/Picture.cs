
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Picture
    {
        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long pic_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long req_itm_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string pic_path { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime pic_add_dm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string pic_comment { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte lvl_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte cat_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int usr_id { get; set; }


        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual PackagingLevel PackagingLevel { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual RequestItem RequestItem { get; set; }
    }
}
