using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;
using Audits;

namespace Audits.Interop
{
    public partial class Sheet : DatabaseObject<Sheet>, ISheet
    {
        private ICollection<ISheetColumn> _sheetColumns;

        public long ID
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
                return sheet_name;
            }
            set
            {
                sheet_name = value;
            }
        }

        public string DefaultDirectory
        {
            get
            {
                return sheet_def_dir;
            }
            set
            {
                sheet_def_dir = value;
            }
        }

        public long Number
        {
            get
            {
                return sheet_num;
            }
            set
            {
                sheet_num = value;
            }
        }

        public string DataTable
        {
            get
            {
                return data_tbl;
            }
            set
            {
                data_tbl = value;
            }
        }

        public long DataRowStart
        {
            get
            {
                return data_row_start;
            }
            set
            {
                data_row_start = value;
            }
        }

        public ICollection<ISheetColumn> SheetColumns
        {
            get
            {
                if (_sheetColumns == null)
                {
                    HashSet<ISheetColumn> cols = new SheetColumn().Where("sheet_id={0}".Format(sheet_id)).ToHashSet<ISheetColumn>();
                    _sheetColumns = cols.Where(s => s.Import == true).OrderBy(o => o.SequenceID).ToHashSet<ISheetColumn>();
                }
                return _sheetColumns;
            }
            set
            {
                _sheetColumns = value;
            }
        }
    }
}
