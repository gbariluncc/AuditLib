using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Audits.Database.DatabaseObjects
{
    public partial class Category : DatabaseObject<Category>, ICategory
    {
        public byte CategoryID
        {
            get
            {
                return cat_id;
            }
            set
            {
                cat_id = value;
            }
        }

        public string CategoryDescription
        {
            get
            {
                return cat_desc;
            }
            set
            {
                cat_desc = value;
            }
        }

        public byte CategoryGroup
        {
            get
            {
                return cat_grp;
            }
            set
            {
                cat_grp = value;
            }
        }

        public byte? CategorySummaryGroup
        {
            get
            {
                return cat_smry_grp == 0? null: new byte?(cat_smry_grp);
            }
            set
            {
                cat_smry_grp = value.Value;
            }
        }

        ICollection<IAudit> ICategory.Audits
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IAudit, Audit>(Audits);
            }
            set
            {
                Audits = InterfaceConverter.ConvertToCollection<Audit, IAudit>(value);
            }
        }

        ICollection<ICategory> ICategory.SubCategories
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<ICategory, Category>(SubCategories);
            }
            set
            {
                SubCategories = InterfaceConverter.ConvertToCollection<Category, ICategory>(value);
            }
        }

        ICategory ICategory.ParentCategory
        {
            get
            {
                return ParentCategory;
            }
            set
            {
                ParentCategory = (Category)value;
            }
        }

        ICollection<IDimension> ICategory.Dimensions
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IDimension, Dimension>(Dimensions);
            }
            set
            {
                Dimensions = InterfaceConverter.ConvertToCollection<Dimension, IDimension>(value);
            }
        }

        ICollection<IRequest> ICategory.Requests
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IRequest, Request>(Requests);
            }
            set
            {
                Requests = InterfaceConverter.ConvertToCollection<Request, IRequest>(value);
            }
        }

        ICategory ICategory.Category
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
