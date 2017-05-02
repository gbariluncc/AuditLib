using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Services;

namespace Audits.Database
{
    public interface IProjectUser : ISubject
    {
        int UserID { get; set; }
        long ProjectID { get; set; }
        byte RoleID { get; set; }
        bool IsSelected { get; set; }

        IUser User { get; }
        IProject Project { get; }
        IRole Role { get; }

    }
}
