using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IPriority : IDatabaseObject<Priority>
    {
        byte PriorityLevel { get; set; }
        string Description { get; set; }
        byte DaysToComplete { get; set; }

        ICollection<ITask> Tasks { get; set; }
        IPriority Priority { get; set; }
    }
}
