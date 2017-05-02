using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class RequestItemType : DatabaseObject<RequestItemType>, IRequestItemType
    {
        public byte ItemTypeID
        {
            get
            {
                return itm_typ_id;
            }
            set
            {
                itm_typ_id = value;
            }
        }

        public string Description
        {
            get
            {
                return itm_typ_desc;
            }
            set
            {
                itm_typ_desc = value;
            }
        }

        public string LongDescription
        {
            get
            {
                return itm_typ_lngdesc;
            }
            set
            {
                itm_typ_lngdesc = value;
            }
        }

        ICollection<IRequestItem> IRequestItemType.RequestItems
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IRequestItem, RequestItem>(RequestItems);
            }
            set
            {
                RequestItems = InterfaceConverter.ConvertToCollection<RequestItem, IRequestItem>(value);
            }
        }

        IRequestItemType IRequestItemType.RequestItemType
        {
            get
            {
                return this;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DBObjectState ObjectState
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
