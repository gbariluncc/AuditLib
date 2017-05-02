using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;
using System.Windows.Media;

namespace Audits.Database.DatabaseObjects
{
    public partial class Request : DatabaseObject<Request>, IRequest
    {
        private bool _isSelected;

        public long RequestID
        {
            get
            {
                return req_id;
            }
            set
            {
                req_id = value;
            }
        }
        public string Requestor
        {
            get { return req_requestor; }
            set { req_requestor = value; }
        }
        public long ProjectID
        {
            get
            {
                return proj_id;
            }
            set
            {
                proj_id = value;
            }
        }

        public DateTime AddDate
        {
            get
            {
                return req_add_dt;
            }
            set
            {
                req_add_dt = value;
            }
        }

        public string Instructions
        {
            get
            {
                return req_instr;
            }
            set
            {
                req_instr = value;
            }
        }
        public DateTime UpdateDate
        {
            get { return req_upd_dm; }
            set { req_upd_dm = value; }
        }
        public bool IsSafety
        {
            get
            {
                return req_is_safety;
            }
            set
            {
                req_is_safety = value;
            }
        }

        public DateTime ExpectedCompleteDate
        {
            get
            {
                return req_exp_comp_dt;
            }
            set
            {
                req_exp_comp_dt = value;
            }
        }

        public byte StatusCode
        {
            get
            {
                return sts_cd;
            }
            set
            {
                sts_cd = value;
                if (Status == null || Status.sts_cd != sts_cd)
                {
                    Status = new Status().Where("sts_cd=" + sts_cd).SingleOrDefault();
                    //this.EntityState = System.Data.Entity.EntityState.Modified;
                }
            }
        }
        public int ShipFromVBU
        {
            get { return req_sf_vbu; }
            set { req_sf_vbu = value; }
        }
        public string DocumentFolder
        {
            get
            {
                return req_doc_fldr;
            }
            set
            {
                req_doc_fldr = value;
            }
        }

        public string Title
        {
            get
            {
                return req_title;
            }
            set
            {
                req_title = value;
            }
        }

        public bool IsPermanent
        {
            get
            {
                return req_is_perm;
            }
            set
            {
                req_is_perm = value;
            }
        }
        public Geometry Icon
        {
            get 
            {
                Source s = this.Project.Source;
                return s.Icon; 
            }
        }
        IProject IRequest.Project
        {
            get
            {
                return Project;
            }
            set
            {
                Project = (Project)value;
            }
        }
        public bool IsSelected 
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
        IStatus IRequest.Status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = (Status)value;
                if (Status.sts_cd != StatusCode)
                {
                    StatusCode = Status.StatusCode;
                    //this.EntityState = System.Data.Entity.EntityState.Modified;
                }
            }
        }

        ICollection<IRequestItem> IRequest.RequestItems
        {
            get
            {
                return RequestItems.ToHashSet<IRequestItem>();
            }
            set
            {
                RequestItems = InterfaceConverter.ConvertToCollection<RequestItem, IRequestItem>(value);
            }
        }

        ICollection<ITask> IRequest.Tasks
        {
            get
            {
                return Tasks.ToHashSet<ITask>();
            }
            set
            {
                Tasks = InterfaceConverter.ConvertToCollection<Task, ITask>(value);
            }
        }

        ICollection<ICategory> IRequest.Categories
        {
            get
            {
                return Categories.ToHashSet<ICategory>();
            }
            set
            {
                Categories = InterfaceConverter.ConvertToCollection<Category, ICategory>(value);
            }
        }

        IRequest IRequest.Request
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
                return DBObjectState.StateObjectUnchanged;
            }
            set
            {
                
            }
        }
        public static bool operator ==(Request obj1, Request obj2)
        {
            if (object.ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if(object.ReferenceEquals(obj1,null)||
                object.ReferenceEquals(obj2, null))
            {
                return false;
            }
            return obj1.req_id == obj2.req_id;
        }
        public static bool operator !=(Request obj1, Request obj2)
        {
            return !(obj2 == obj1);
        }
        public override bool Equals(object obj)
        {
            if (obj is Request)
            {
                return (obj as Request) == this;
            }
            return false;
        }
    }
}
