using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;

namespace Audits.Interop
{
    //database facing
    public partial class SheetColumn
    {
        public long col_id { get; set; }
        public long sheet_id { get; set; }
        public string col_name { get; set; }
        public bool col_import { get; set; }
        public long col_num { get; set; }
        public string col_ltr { get; set; }
        public string col_tbl_map { get; set; }
        public long col_seq_id { get; set; }
        public bool obj_skip { get; set; }
    }
}
