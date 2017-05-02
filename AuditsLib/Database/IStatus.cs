using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IStatus : IDatabaseObject<Status>
    {
        byte StatusCode { get; set; }
        string Description { get; set; }

        ICollection<IFailedSample> FailedSamples { get; set; }
        ICollection<IProject> Projects { get; set; }
        ICollection<IRequest> Requests { get; set; }
        ICollection<IRequestItem> RequestItems { get; set; }
        ICollection<ITask> Tasks { get; set; }
        IStatus Status { get; set; }
    }
}
