using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;
using Audits;

namespace Audits.Interop
{
    public partial class SheetColumn :  DatabaseObject<SheetColumn>, ISheetColumn
    {
        private ISheet _sheet;

        public long ColumnID
        {
            get
            {
                return col_id;
            }
            set
            {
                col_id = value;
            }
        }

        public long SheetID
        {
            get
            {
                return sheet_id;
            }
            set
            {
                sheet_id = value;
            }
        }

        public string Name
        {
            get
            {
                return col_name;
            }
            set
            {
                col_name = value;
            }
        }

        public bool Import
        {
            get
            {
                return col_import;
            }
            set
            {
                col_import = value;
            }
        }

        public long ColumnNumber
        {
            get
            {
                return col_num;
            }
            set
            {
                col_num = value;
            }
        }

        public string ColumnLetter
        {
            get
            {
                return col_ltr;
            }
            set
            {
                col_ltr = value;
            }
        }

        public string TableMap
        {
            get
            {
                return col_tbl_map;
            }
            set
            {
                col_tbl_map = value;
            }
        }
        public long SequenceID
        {
            get { return col_seq_id; }
            set { col_seq_id = value; }
        }
        public bool ObjSkip
        {
            get { return obj_skip; }
            set { obj_skip = value; }
        }
        public ISheet Sheet
        {
            get
            {
                if (_sheet == null)
                {
                    _sheet = new Sheet().Where("sheet_id={0}".Format(SheetID)).FirstOrDefault();
                }
                return _sheet;
            }
            set
            {
                _sheet = value;
            }
        }
    }
}
