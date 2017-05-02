using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;

using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public class DataSeverConnection : DatabaseConnection
    {
        private static DataSeverConnection _instance;

        private DataSeverConnection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
            Account = new Account() { LogonID = string.Empty, Password = string.Empty };
            this.Open(Account);
        }
        public static DataSeverConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataSeverConnection();
                }
                return _instance;
            }
        }

        public override void Open()
        {
            if (base.Connection == null || base.Connection.State == 0)
            {
                this.Open(base.Account);
            }
        }
        public override bool Open(string pw, string id)
        {
            IAccount a = new Account() { LogonID = id, Password = pw };
            return this.Open(a);
        }
        public override bool Open(IAccount account)
        {
            ADODB.Connection cn = new ADODB.Connection();
            cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
            cn.ConnectionString = ConnectionString;

            try
            {
                cn.Open(ConnectionString);
                base.Account = account;
                base.Connection = cn;
                return true;
            }
            catch (Exception err) { MessageBox.Show("Connection Error - Please try again.\n" + err.Message); return false; }
        }
    }
}
