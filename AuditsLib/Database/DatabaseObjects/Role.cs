

namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Role
    {
        public Role()
        {
            //this.Users = new HashSet<User>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte role_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string role_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte role_acc_lvl { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<User> Users { get; set; }
    }
}
