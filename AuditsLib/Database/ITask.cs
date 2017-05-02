using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface ITask : IDatabaseObject<Task>, IEquatable<ITask>
    {
        long TaskID { get; set; }
        long RequestID { get; set; }
        int UserID { get; set; }
        DateTime AssignDate { get; set; }
        DateTime DueDate { get; set; }
        DateTime UpdateDate { get; set; }
        byte PriorityLevel { get; set; }
        byte StatusCode { get; set; }
        string Comments { get; set; }
        bool IsLoaded { get; }
        bool IsNew { get; set; }

        IPriority Priority { get; set; }
        IRequest Request { get; set; }
        IStatus Status { get; set; }
        IUser User { get; set; }
        ITask Task { get; set; }
    }
}
