using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;

namespace Audits.Database.HostObjects
{
    public class VendorItem : RequestItemDecorator
    {
        public VendorItem(IRequestItem requestItem)
            : base(requestItem)
        {

        }
    }
}
