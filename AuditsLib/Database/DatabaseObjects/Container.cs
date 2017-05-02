using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits;

namespace Audits.Database.DatabaseObjects
{
    public partial class Container
    {
        private HashSet<RequestItem> _requestItems;
        public Container()
        {
            this.RequestItems = new HashSet<RequestItem>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte cont_typ { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string cont_desc { get; set; }

        public virtual ICollection<RequestItem> RequestItems 
        {
            get
            {
                if (_requestItems == null)
                {
                    _requestItems = new RequestItem().Where("con_typ=" + cont_typ).ToHashSet();
                }
                return _requestItems;
            }

            set { _requestItems = (HashSet<RequestItem>)value; }
        }
    }
}
