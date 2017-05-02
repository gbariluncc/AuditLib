using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IProject : IDatabaseObject<Project>
    {
        long ProjectID { get; set; }
        DateTime AddDate { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        bool IsPublic { get; set; }
        byte SourceID { get; set; }
        byte StatusCode { get; set; }

        ISource Source { get; set; }
        IStatus Status { get; set; }
        ICollection<IRequest> Requests { get; set; }

    }
}
