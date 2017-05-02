using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using Audits.Database;
using System.Configuration;
using System.Windows;

namespace Audits.Database
{
    public class DMSConnection : DatabaseConnection
    {
        private static DMSConnection _instance = new DMSConnection();

        private DMSConnection()
        {

        }

        public static DMSConnection GetInstance()
        {
            return _instance;
        }

        public override void Open()
        {
            if (base.Connection.State == 0)
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
            if (string.IsNullOrEmpty(account.LogonID) && string.IsNullOrEmpty(account.Password)) { return false; }

            base.Account = account;

            string conn = ConfigurationManager.ConnectionStrings["ODBCRemote"].ConnectionString;
            ADODB.Connection cn = new ADODB.Connection();
            cn.ConnectionString = conn;
            try
            {
                cn.Open(conn, account.LogonID, account.Password);
                base.Connection = cn;
                return true;
            }
            catch (Exception err) { MessageBox.Show("Incorrect Password - Please try again.\n" + err.Message); return false; }
        }
    }
}
