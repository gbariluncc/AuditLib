using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IGroup : IDatabaseObject<Group>
    {
        int GroupID { get; set; }
        string GroupName { get; set; }
        string Description { get; set; }

        ICollection<IEmailGroup> EmailAddresses { get; }
    }
}
