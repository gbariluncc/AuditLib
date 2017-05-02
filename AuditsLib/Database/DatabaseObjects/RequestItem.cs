
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Audits.Database.DataAccessLayer;

    public partial class RequestItem
    {
        private RequestItem _parent;
        private HashSet<RequestItem> _children;
        private Container _container;
        private HashSet<Dimension> _Dimensions;
        private HashSet<Audit> _audits;
        private Request _request;
        private RequestItemType _requestItemType;
        private HashSet<Picture> _pictures;
        private Status _status;

        public RequestItem()
        {
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long req_itm_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte itm_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int req_itm_val { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte sts_cd { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long req_itm_par_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime req_itm_add_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime req_itm_upd_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime req_itm_exp_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long req_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte cont_typ { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string req_itm_comm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long vbu { get; set; }


        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual ICollection<Audit> Audits 
        {
            get
            {
                if (_audits == null)
                {
                    _audits = new Audit().Where("req_itm_id=" + RequestItemID).ToHashSet();
                }
                return _audits;
            }
            set { }
        }
        public virtual Container Container 
        {
            get
            {
                if (_container == null)
                {
                    _container = new Container().Where("cont_typ=" + cont_typ).SingleOrDefault();
                }
                return _container;
            }
            set
            {
                _container = value;
            }
        }
        public virtual ICollection<Dimension> Dimensions 
        {
            get
            {
                if (_Dimensions == null)
                {
                    _Dimensions = new Dimension().Where("req_itm_id=" + req_itm_id).ToHashSet();
                }
                return _Dimensions;
            }
            set { _Dimensions = (HashSet<Dimension>)value; }
        }
        public virtual ICollection<Picture> Pictures 
        {
            get
            {
                if (_pictures == null)
                {
                    _pictures = new Picture().Where("req_itm_id=" + req_itm_id).ToHashSet();
                }
                return _pictures;
            }
            set { _pictures = (HashSet<Picture>)value; }
        }
        public virtual Request Request 
        {
            get
            {
                if (_request == null)
                {
                    _request = new Request().Where("req_id=" + req_id).SingleOrDefault();
                }
                return _request;
            }
            set { _request = value; }
        }
        public virtual RequestItemType RequestItemType 
        {
            get
            {
                if (_requestItemType == null)
                {
                    _requestItemType = new RequestItemType().Where("itm_typ_id=" + itm_typ_id).SingleOrDefault();
                }
                return _requestItemType;
            }
            set { _requestItemType = value; }
        }
        public virtual ICollection<RequestItem> Children 
        {
            get
            {
                /*if (_children == null)
                {*/
                    _children = new RequestItem().Where("req_itm_par_id=" + req_itm_id).ToHashSet();
                //}
                return _children;
            }
            set
            {
                _children = (HashSet<RequestItem>)value;
            }
        }
        public virtual RequestItem Parent 
        {
            get
            {
                if (_parent == null)
                {
                    _parent = new RequestItem().Where("req_itm_id=" + req_itm_par_id).SingleOrDefault();
                }
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        public virtual Status Status 
        {
            get
            {
                if (_status == null)
                {
                    _status = new Status().Where("sts_cd=" + sts_cd).SingleOrDefault();
                }
                return _status;
            }
            set { _status = value; }
        }
    }
}
