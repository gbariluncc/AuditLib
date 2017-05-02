using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IRequestItem : IDatabaseObject<RequestItem>, IEquatable<RequestItem>
    {
        long RequestItemID { get; set; }
        byte ItemTypeID { get; set; }
        int Value { get; set; }
        byte StatusCode { get; set; }
        long? ParentID { get; set; }
        DateTime AddDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime ExpDate { get; set; }
        long RequestID { get; set; }
        byte ContainerType { get; set; }
        string Comments { get; set; }
        string Description { get; }
        string DisplayValue { get; }
        string FailedSampleText { get; }
        string DCIssuesText { get; }
        long VBU { get; set; }

        IFailedSample FailedSample { get; }
        IDCIssueItem DCIssueItem { get; }
        ICollection<IAudit> Audits { get; set; }
        IContainer Container { get; set; }
        ICollection<IDimension> Dimensions { get; set; }
        ICollection<IPicture> Pictures { get; set; }
        IRequest Request { get; set; }
        IRequestItemType RequestItemType { get; set; }
        ICollection<IRequestItem> Children { get; set; }
        IRequestItem Parent { get; set; }
        IStatus Status { get; set; }
        IRequestItem RequestItem { get; set; }
    }
}
