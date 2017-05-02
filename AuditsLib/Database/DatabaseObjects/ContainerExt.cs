using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Container : DatabaseObject<Container>, IContainer
    {
        public byte ContainerType
        {
            get
            {
                return cont_typ;
            }
            set
            {
                cont_typ = value;
            }
        }

        public string ContainerDescription
        {
            get
            {
                return cont_desc;
            }
            set
            {
                cont_desc = value;
            }
        }

        ICollection<IRequestItem> IContainer.RequestItems
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

        IContainer IContainer.Container
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
