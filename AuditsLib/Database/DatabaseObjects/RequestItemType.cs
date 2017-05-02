
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class RequestItemType
    {
        public RequestItemType()
        {
            this.RequestItems = new HashSet<RequestItem>();
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte itm_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string itm_typ_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string itm_typ_lngdesc { get; set; }

        public virtual ICollection<RequestItem> RequestItems { get; set; }
    }
}
