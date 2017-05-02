using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public interface IDMSItem : IRequestItem
    {
        int OnHand { get; }
        long Number { get; }
    }
}
