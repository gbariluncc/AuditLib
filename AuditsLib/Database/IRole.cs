using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IRole : IDatabaseObject<Role>
    {
        byte RoleID { get; set; }
        string Description { get; set; }
        byte AccessLevel { get; set; }

        ICollection<IUser> Users { get; set; }
        IRole Role { get; set; }
    }
}
