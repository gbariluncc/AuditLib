using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IRequestItemType : IDatabaseObject<RequestItemType>
    {
        byte ItemTypeID { get; set; }
        string Description { get; set; }
        string LongDescription { get; set; }

        ICollection<IRequestItem> RequestItems { get; set; }
        IRequestItemType RequestItemType { get; set; }
    }
}
