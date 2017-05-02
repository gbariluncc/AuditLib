using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace Audits.Database
{
    public abstract class DatabaseConnection
    {
        private ADODB.Connection _connection;
        private OleDbConnection _oleDBCn;
        private string _cnString;

        public ADODB.Connection Connection
        {
            get
            {
                if (_connection != null)
                {
                    if (_connection.State == 0 && Account != null)
                    {
                        _connection.Open(_connection.ConnectionString, Account.LogonID, Account.Password);
                    }
                }
                return _connection;
            }
            protected set { _connection = value; }
        }
        public IAccount Account { get; set; }

        public ADODB.Recordset Recordset(string sql)
        {
            return this.Recordset(sql, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly);
        }
        public OleDbConnection OleDBConnection()
        {
            if (_oleDBCn == null)
            {
                _oleDBCn = new OleDbConnection(_cnString);
                try
                {
                    _oleDBCn.Open();
                }
                catch (Exception err) { MessageBox.Show("Error opening OLEDB Connection: " + err.Message); }
            }

            return _oleDBCn;
        }
        public string ConnectionString
        {
            get { return _cnString; }
            set { _cnString = value; }
        }
        public ADODB.Recordset Recordset(string sql, ADODB.CursorTypeEnum openType, ADODB.LockTypeEnum lockType)
        {
            try
            {
                if (_connection.State == 0 && Account != null)
                {
                    _connection.Open(UserID: Account.LogonID, Password: Account.Password);
                }
                ADODB.Recordset rs = new ADODB.Recordset();
                rs.Open(sql, this.Connection, openType, lockType);
                return rs;
            }
            catch (Exception) { return null; }
        }
        public DataSet DataSet(string sql, string tableName)
        {
            ADODB.Recordset rs = this.Recordset(sql);
            if (rs == null) return null;

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();

            da.Fill(ds, rs, tableName);
            return ds;
        }
        public bool IsOpen()
        {
            if (this.Connection == null)
            {
                return false;
            }

            return (this.Connection.State != 0);
        }

        //override methods
        public abstract bool Open(IAccount account);
        public abstract void Open();
        public abstract bool Open(string pw, string id);
    }
}
