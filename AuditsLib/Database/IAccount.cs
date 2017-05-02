using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IAccount : IDatabaseObject<Account>
    {
        int UserID { get; set; }
        byte AccountTypeID { get; set; }
        string LogonID { get; set; }
        string Password { get; set; }

        IAccountType AccountType { get; set; }
        IUser User { get; set; }

        IAccount Account { get; set; }
    }
}
