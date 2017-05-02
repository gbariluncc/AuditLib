using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Audit : DatabaseObject<Audit>, IAudit
    {

        public long AuditID
        {
            get
            {
                return audit_id;
            }
            set
            {
                audit_id = value;
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
            }
        }

        public byte RatingID
        {
            get
            {
                return rating_id;
            }
            set
            {
                rating_id = value;
                if (RatingID != Rating.RatingID)
                {
                    Rating = DBContext.Instance.Ratings.GetSingle(r => r.rating_id == RatingID);
                }
            }
        }

        public string AuditComments
        {
            get
            {
                return audit_comm;
            }
            set
            {
                audit_comm = value;
            }
        }

        public DateTime AuditDate
        {
            get
            {
                return audit_dt;
            }
            set
            {
                audit_dt = value;
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
            }
        }

        ICategory IAudit.Category
        {
            get
            {
                return Category;
            }
            set
            {
                Category = (Category)value;
            }
        }

        IRating IAudit.Rating
        {
            get
            {
                return Rating;
            }
            set
            {
                Rating = (Rating)value;
                if (Rating.RatingID != RatingID)
                {
                    RatingID = Rating.RatingID;
                }
            }
        }

        IRequestItem IAudit.RequestItem
        {
            get
            {
                return RequestItem;
            }
            set
            {
                RequestItem = (RequestItem)value;
            }
        }

        IUser IAudit.User
        {
            get
            {
                return User;
            }
            set
            {
                User = (User)value;
            }
        }

        IAudit IAudit.Audit
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
