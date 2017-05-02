using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Auditor
    {
        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public int usr_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool aud_gets_failsam { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual User User { get; set; }
    }
}
