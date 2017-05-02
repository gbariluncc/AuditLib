using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Interop
{
    public partial class Import<T> where T : class, new()
    {
        //DB Facing class
        public long import_id { get; set; }
        public byte import_month { get; set; }
        public int import_year { get; set; }
        public int import_week { get; set; }
        public DateTime add_dt { get; set; }
        public DateTime upd_dm { get; set; }
        public int sheet_id { get; set; }
        public string file_path { get; set; }
    }
}
