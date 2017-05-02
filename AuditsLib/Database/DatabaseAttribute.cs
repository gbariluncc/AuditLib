using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DatabaseAttribute : Attribute
    {
        private bool _dbField;
        private bool _isPrimary;
        private bool _isReadOnly;
        private OleDbType _dbType;
        private int _fldSize;

        public DatabaseAttribute()
        {

        }
        public DatabaseAttribute(bool IsDBField, bool IsPrimary, bool IsReadOnly)
        {
            _dbField = IsDBField;
            _isPrimary = IsPrimary;
            _isReadOnly = IsReadOnly;
        }
        public virtual int FieldSize
        {
            get { return _fldSize; }
            set { _fldSize = value; }
        }
        public virtual bool IsDBField
        {
            get
            {
                return _dbField;
            }
            set
            {
                _dbField = value;
            }
        }
        public virtual OleDbType DataType
        {
            get
            {
                return _dbType;
            }
            set
            {
                _dbType = value;
            }
        }
        public virtual bool IsPrimary
        {
            get { return _isPrimary; }
            set { _isPrimary = value; }
        }
        public virtual bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { _isReadOnly = value; }
        }
    }
}
