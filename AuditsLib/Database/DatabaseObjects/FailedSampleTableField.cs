namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class FailedSampleTableField
    {
        public byte fld_id { get; set; }
        public string fld_nme { get; set; }
        public bool fld_in_use { get; set; }
        public int sheet_id { get; set; }

        public virtual FailedSampleItemSheet FailedSampleItemSheet { get; set; }
    }
}
