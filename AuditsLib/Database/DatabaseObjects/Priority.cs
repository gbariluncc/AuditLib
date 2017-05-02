

namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Priority
    {
        public Priority()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte prior_lvl { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string prior_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte prior_days_to_comp { get; set; }


        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
