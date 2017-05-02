using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Account : DatabaseObject<Account>, IAccount
    {
        public int UserID
        {
            get
            {
                return usr_id;
            }
            set
            {
                usr_id = value;
            }
        }

        public byte AccountTypeID
        {
            get
            {
                return acc_typ_id;
            }
            set
            {
                acc_typ_id = value;
            }
        }

        public string LogonID
        {
            get
            {
                return acc_logon_id;
            }
            set
            {
                acc_logon_id = value;
            }
        }

        public string Password
        {
            get
            {
                return acc_password;
            }
            set
            {
                acc_password = value;
            }
        }

        IAccountType IAccount.AccountType
        {
            get
            {
                return AccountType;
            }
            set
            {
                AccountType = (AccountType)value;
            }
        }

        IUser IAccount.User
        {
            get
            {
                return User;
            }
            set
            {
                User = (User)value;
            }
        }

        IAccount IAccount.Account
        {
            get
            {
                return this;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public DBObjectState ObjectState
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
