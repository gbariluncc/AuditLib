using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Interop
{
    public partial class Sheet
    {
        //DB Facing class

        public long sheet_id { get; set; }
        public string sheet_name { get; set; }
        public string sheet_def_dir { get; set; }
        public long sheet_num { get; set; }
        public string data_tbl { get; set; }
        public long data_row_start { get; set; }
    }
}
