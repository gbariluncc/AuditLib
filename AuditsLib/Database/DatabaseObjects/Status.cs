

namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Status
    {
        public Status()
        {
            this.FailedSamples = new HashSet<FailedSample>();
            this.Projects = new HashSet<Project>();
            this.Requests = new HashSet<Request>();
            this.RequestItems = new HashSet<RequestItem>();
            this.Tasks = new HashSet<Task>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte sts_cd { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string sts_desc { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<FailedSample> FailedSamples { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Project> Projects { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Request> Requests { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<RequestItem> RequestItems { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
