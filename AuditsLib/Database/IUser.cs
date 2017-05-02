using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IUser : IDatabaseObject<User>
    {
        int UserID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PCLogon { get; set; }
        short FacilityNumber { get; set; }
        byte RoleID { get; set; }

        ICollection<IAccount> Accounts { get; set; }
        ICollection<IAudit> Audits { get; set; }
        IAuditor Auditor { get; set; }
        ICollection<IDimension> Dimensions { get; set; }
        IRole Role { get; set; }
        ICollection<ITask> Tasks { get; set; }

    }
}
