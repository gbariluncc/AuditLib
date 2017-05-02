
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Project
    {
        public Project()
        {
            //this.Requests = new HashSet<Request>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long proj_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime proj_add_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string proj_title { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string proj_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool proj_is_public { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte source_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte sts_cd { get; set; }


        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual Source Source { get; set; }
        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual Status Status { get; set; }
        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
