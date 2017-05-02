using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using System.Windows.Media;

namespace Audits.Database
{
    public interface IRequest : IDatabaseObject<Request>
    {
        long RequestID { get; set; }
        long ProjectID { get; set; }
        DateTime AddDate { get; set; }
        string Instructions { get; set; }
        bool IsSafety { get; set; }
        DateTime ExpectedCompleteDate { get; set; }
        byte StatusCode { get; set; }
        string DocumentFolder { get; set; }
        string Title { get; set; }
        bool IsPermanent { get; set; }
        DateTime UpdateDate { get; set; }
        string Requestor { get; set; }
        int ShipFromVBU { get; set; }
        Geometry Icon { get; }
        bool IsSelected { get; set; }

        IProject Project { get; set; }
        IStatus Status { get; set; }
        ICollection<IRequestItem> RequestItems { get; set; }
        ICollection<ITask> Tasks { get; set; }
        ICollection<ICategory> Categories { get; set; }
        IRequest Request { get; set; }
    }
}
