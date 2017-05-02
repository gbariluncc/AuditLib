using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public class HostConnection : DatabaseConnection
    {
        private static HostConnection _instance = new HostConnection();

        private HostConnection()
        {
            //base.Account = CurrentUser.GetInstance().GetAccount(5);
        }

        public static HostConnection GetInstance()
        {
            return _instance;
        }

        public override void Open()
        {
            if (base.Connection == null || base.Connection.State == 0)
            {
                this.Open(base.Account);
            }
        }
        public override bool Open(string id, string pw)
        {
            IAccount a = new Account() { LogonID = id, Password = pw };
            return this.Open(a);
        }
        public override bool Open(IAccount account)
        {
            if (string.IsNullOrEmpty(account.LogonID) && string.IsNullOrEmpty(account.Password)) { return false; }

            string conn = ConfigurationManager.ConnectionStrings["HostRemote"].ConnectionString;
            ADODB.Connection cn = new ADODB.Connection();
            cn.ConnectionString = conn;
            try
            {
                cn.Open(conn, account.LogonID, account.Password);
                base.Account = account;
                base.Connection = cn;
                return true;
            }
            catch (Exception err) { MessageBox.Show("Incorrect Password - Please try again.\n" + err.Message); return false; }
        }
    }
}
