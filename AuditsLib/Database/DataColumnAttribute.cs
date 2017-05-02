using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataColumnAttribute : Attribute
    {
        private bool _isDataCol;
        private int _colPos;

        public DataColumnAttribute(bool isDataColumn)
        {
            _isDataCol = isDataColumn;
        }

        public bool IsDataColumn
        {
            get { return _isDataCol; }
            set { _isDataCol = value; }
        }
        public virtual int ColumnPosition
        {
            get { return _colPos; }
            set { _colPos = value; }
        }
    }
}
