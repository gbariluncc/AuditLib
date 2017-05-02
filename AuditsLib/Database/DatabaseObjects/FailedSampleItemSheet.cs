
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class FailedSampleItemSheet
    {
        public FailedSampleItemSheet()
        {
            this.FailedSampleTableFields = new HashSet<FailedSampleTableField>();
        }

        public int sheet_id { get; set; }
        public byte sheet_data_row { get; set; }
        public string sheet_name { get; set; }

        public virtual ICollection<FailedSampleTableField> FailedSampleTableFields { get; set; }
    }
}
