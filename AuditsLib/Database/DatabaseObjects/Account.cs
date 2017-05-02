using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Account
    {
        private AccountType _accountType;
        private User _user;

        [Database(IsDBField=true, IsPrimary=true, IsReadOnly=false)]
        public int usr_id { get; set; }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte acc_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string acc_logon_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string acc_password { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual AccountType AccountType 
        {
            get
            {
                if (_accountType == null)
                {
                    _accountType = new AccountType().Where("acc_typ_id=" + acc_typ_id).SingleOrDefault();
                }
                return _accountType;
            }
            set
            {
                _accountType = value;
            }
        }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual User User 
        {
            get
            {
                if (_user == null)
                {
                    _user = new User().Where("usr_id=" + usr_id).SingleOrDefault();
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
