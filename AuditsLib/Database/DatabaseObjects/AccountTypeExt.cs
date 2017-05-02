using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class AccountType : DatabaseObject<AccountType>, IAccountType
    {

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

        public string AccountDescription
        {
            get
            {
                return acc_typ_desc;
            }
            set
            {
                acc_typ_desc = value;
            }
        }


        IAccountType IAccountType.AccountType
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


        ICollection<IAccount> IAccountType.Accounts
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
