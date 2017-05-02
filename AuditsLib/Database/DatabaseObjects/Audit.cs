using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Audit
    {
        private Category _category;
        private Rating _rating;
        private RequestItem _requestItem;
        private User _user;

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long audit_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long req_itm_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte cat_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte rating_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string audit_comm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime audit_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int usr_id { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual Category Category 
        {
            get
            {
                if (_category == null)
                {
                    _category = new Category().Where("cat_id=" + cat_id).SingleOrDefault();
                }
                return _category;
            }
            set { _category = value; }
        }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual Rating Rating 
        {
            get
            {
                if (_rating == null)
                {
                    _rating = new Rating().Where("rating_id=" + rating_id).SingleOrDefault();
                }
                return _rating;
            }
            set 
            { 
                _rating = value;
                if (_rating != null && (rating_id != _rating.RatingID))
                {
                    rating_id = _rating.RatingID;
                }
            }
        }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual RequestItem RequestItem 
        {
            get
            {
                if (_requestItem == null)
                {
                    _requestItem = new RequestItem().Where("req_itm_id=" + req_itm_id).SingleOrDefault();
                }
                return _requestItem;
            }
            set
            {
                _requestItem = value;
                if (_requestItem.req_itm_id != req_itm_id)
                {
                    req_itm_id = _requestItem.req_itm_id;
                }
            }
        }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual User User 
        {
            get
            {
                if (_user == null)
                {
                    _user = new User().Where("usr_id=" + usr_id).SingleOrDefault();
                }
                return _user;
            }
            set
            {
                _user = value;
                if (_user.usr_id != usr_id)
                {
                    usr_id = _user.usr_id;
                }
            }
        }
    }
}
