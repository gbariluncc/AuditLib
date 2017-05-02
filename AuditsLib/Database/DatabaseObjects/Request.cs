
namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Audits.Database.DataAccessLayer;


    public partial class Request
    {
        private ICollection<RequestItem> _requestItems;
        private Project _project;
        private Status _status;
        private HashSet<Task> _task;
        private HashSet<Category> _categories;

        public Request()
        {
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long req_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long proj_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime req_add_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string req_instr { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool req_is_safety { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime req_exp_comp_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte sts_cd { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string req_doc_fldr { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string req_title { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool req_is_perm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime req_upd_dm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string req_requestor { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int req_sf_vbu { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual Project Project 
        {
            get
            {
                if (_project == null)
                {
                    _project = new Project().Where("proj_id=" + proj_id).SingleOrDefault();
                }
                return _project;
            }
            set
            {
                _project = value;
            }
        }
        public virtual Status Status 
        {
            get
            {
                if (_status == null)
                {
                    _status = new Status().Where("sts_cd=" + sts_cd).FirstOrDefault();
                }
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public virtual ICollection<RequestItem> RequestItems 
        {
            get
            {
                return new RequestItem().Where("req_id=" + RequestID + " AND req_itm_par_id=0").ToHashSet(); 
            }
            set
            {
                _requestItems = value;
            }
        }
        public virtual ICollection<Task> Tasks 
        {
            get
            {
                if (_task == null)
                {
                    _task = new Task().Where("req_id=" + RequestID).ToHashSet();
                }
                return _task;
            }
            set
            {
                _task = (HashSet<Task>)value;
            }
        }

        public virtual ICollection<Category> Categories 
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new HashSet<Category>();
                    HashSet<RequestCategory> temp = new RequestCategory().Where("req_id=" + req_id).ToHashSet();
                    temp.Each(t =>
                    {
                        _categories.Add(t.Category);
                    });
                }
                return _categories;
            }
            set { _categories = (HashSet<Category>)value; }
        }
    }
}
