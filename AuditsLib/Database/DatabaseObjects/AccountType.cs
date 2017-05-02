using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class AccountType
    {
        private HashSet<Account> _accounts;
        public AccountType()
        {
            //this.Accounts = new HashSet<Account>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte acc_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string acc_typ_desc { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Account> Accounts 
        {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new Account().Where("acc_typ_id=" + acc_typ_id).ToHashSet();
                }
                return _accounts;
            }
            set
            {
                _accounts = (HashSet<Account>)value;
            }
        }
    }
}
