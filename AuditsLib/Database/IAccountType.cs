using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IAccountType : IDatabaseObject<AccountType>
    {
        byte AccountTypeID { get; set; }
        string AccountDescription { get; set; }

        ICollection<IAccount> Accounts { get; set; }
        IAccountType AccountType { get; set; }
    }
}
