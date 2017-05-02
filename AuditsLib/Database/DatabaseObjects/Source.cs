using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Source
    {
        public Source()
        {
            //this.Projects = new HashSet<Project>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte source_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string source_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string source_icon { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
