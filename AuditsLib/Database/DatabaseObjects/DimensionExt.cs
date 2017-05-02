using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;


namespace Audits.Database.DatabaseObjects
{
    public partial class Dimension : DatabaseObject<Dimension>, IDimension
    {

        public long DimensionID
        {
            get
            {
                return dim_id;
            }
            set
            {
                dim_id = value;
                NeedsToSave = true;
            }
        }

        public long RequestItemID
        {
            get
            {
                return req_itm_id;
            }
            set
            {
                req_itm_id = value;
                NeedsToSave = true;
            }
        }

        public byte LevelID
        {
            get
            {
                return lvl_id;
            }
            set
            {
                lvl_id = value;
                NeedsToSave = true;
                if (PackagingLevel == null || PackagingLevel.LevelID != LevelID)
                {
                    PackagingLevel = DBContext.Instance.PackagingLevels.GetSingle(p => p.lvl_id == LevelID);
                }
            }
        }

        public double Length
        {
            get
            {
                return dim_len;
            }
            set
            {
                dim_len = value;
                NeedsToSave = true;
            }
        }

        public double Width
        {
            get
            {
                return dim_wid;
            }
            set
            {
                dim_wid = value;
                NeedsToSave = true;
            }
        }

        public double Height
        {
            get
            {
                return dim_hgt;
            }
            set
            {
                dim_hgt = value;
                NeedsToSave = true;
            }
        }

        public double Weight
        {
            get
            {
                return dim_wgt;
            }
            set
            {
                dim_wgt = value;
                NeedsToSave = true;
            }
        }

        public int Quantity
        {
            get
            {
                return dim_qty;
            }
            set
            {
                dim_qty = value;
                NeedsToSave = true;
            }
        }

        public DateTime AddDate
        {
            get
            {
                return dim_add_dt;
            }
            set
            {
                dim_add_dt = value;
                NeedsToSave = true;
            }
        }

        public byte CategoryID
        {
            get
            {
                return cat_id;
            }
            set
            {
                cat_id = value;
                NeedsToSave = true;
            }
        }

        public int UserID
        {
            get
            {
                return usr_id;
            }
            set
            {
                usr_id = value;
                NeedsToSave = true;
            }
        }

        public int? StackHeight
        {
            get
            {
                return dim_stk_hgt;
            }
            set
            {
                dim_stk_hgt = value.Value;
                NeedsToSave = true;
            }
        }

        public double? PrintedWeight
        {
            get
            {
                return dim_pkg_wgt;
            }
            set
            {
                dim_pkg_wgt = value.Value;
                NeedsToSave = true;
            }
        }

        public string Comments
        {
            get
            {
                return dim_comm;
            }
            set
            {
                dim_comm = value;
                NeedsToSave = true;
            }
        }

        ICategory IDimension.Category
        {
            get
            {
                return Category;
            }
            set
            {
                Category = (Category)value;
                NeedsToSave = true;
            }
        }

        IPackagingLevel IDimension.PackagingLevel
        {
            get
            {
                if (PackagingLevel == null)
                {
                    PackagingLevel = new PackagingLevel().Where("lvl_id={0}".Format(lvl_id)).FirstOrDefault();
                }
                return PackagingLevel;
            }
            set
            {
                PackagingLevel = (PackagingLevel)value;
                NeedsToSave = true;
                if (PackagingLevel != null && PackagingLevel.LevelID != LevelID)
                {
                    LevelID = PackagingLevel.LevelID;
                }
            }
        }

        IRequestItem IDimension.RequestItem
        {
            get
            {
                return RequestItem;
            }
            set
            {
                RequestItem = (RequestItem)value;
                NeedsToSave = true;
            }
        }

        IUser IDimension.User
        {
            get
            {
                return User;
            }
            set
            {
                User = (User)value;
                NeedsToSave = true;
            }
        }

        IDimension IDimension.Dimension
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
