using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public class DCPO : RequestItemDecorator, IPrintableAuditItem
    {
        private IPOWithStatus _po;

        public DCPO(IRequestItem requestItem)
            : base(requestItem)
        {
            _po = new POWithStatus(requestItem.Value);

        }
        public IPOWithStatus PO
        {
            get { return _po; }
        }
        public long TotalOH
        {
            get { return _po.OrdQty; }
        }

        public DCLocation Forward
        {
            get { return null; }
        }

        public ICollection<DCLocation> Reserves
        {
            get { return new HashSet<DCLocation>(); }
        }
    }
}
