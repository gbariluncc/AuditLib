using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits;
using Audits.Database;

namespace Audits.Interop
{
    public partial class Import<T> : DatabaseObject<Import<T>>, IImport<T> where T: class, new()
    {
        private ISheet _sheet;
        private HashSet<T> _importData;

        public string FilePath
        {
            get { return file_path; }
            set { file_path = value; }
        }
        public long ImportID
        {
            get
            {
                return import_id;
            }
            set
            {
                import_id = value;
            }
        }

        public byte ImportMonth
        {
            get
            {
                return import_month;
            }
            set
            {
                import_month = value;
            }
        }

        public int ImportYear
        {
            get
            {
                return import_year;
            }
            set
            {
                import_year = value;
            }
        }
        public int ImportWeek
        {
            get { return import_week; }
            set { import_week = value; }
        }
        public DateTime AddDate
        {
            get
            {
                return add_dt;
            }
            set
            {
                add_dt = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return upd_dm;
            }
            set
            {
                upd_dm = value;
            }
        }

        public int SheetID
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

        public ISheet Sheet
        {
            get
            {
                if (_sheet == null)
                {
                    _sheet = new Sheet().Where("sheet_id={0}".Format(sheet_id)).FirstOrDefault();
                }
                return _sheet;
            }
            set
            {
                _sheet = value;
            }
        }

        public ICollection<T> ImportData
        {
            get
            {
                if (_importData == null)
                {
                    _importData = (new T() as DatabaseObject<T>).Where("import_id={0}".Format(import_id)).ToHashSet<T>();
                    
                }
                return _importData;
            }
            set
            {
                _importData = (HashSet<T>)value;
            }
        }
    }
}
