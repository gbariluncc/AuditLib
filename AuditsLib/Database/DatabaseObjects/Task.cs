using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    using System;
    using System.Collections.Generic;

    public partial class Task
    {
        private Priority _priority;
        private Request _request;
        private Status _status;
        private User _user;

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long task_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long req_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int usr_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime task_assgn_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte prior_lvl { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte sts_cd { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime task_due_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime task_upd_dt { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string task_comm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public bool is_new { get; set; }

        public virtual Priority Priority 
        {
            get
            {
                if (_priority == null)
                {
                    _priority = new Priority().Where("prior_lvl=" + prior_lvl).SingleOrDefault();
                }
                return _priority;
            }
            set { _priority = value; }
        }
        public virtual Request Request 
        {
            get
            {
                if (_request == null)
                {
                    _request = new Request().Where("req_id=" + req_id).FirstOrDefault();
                }
                return _request;
            }
            set
            {
                _request = value;
            }
        }
        public virtual Status Status 
        {
            get
            {
                return new Status().Where("sts_cd=" + sts_cd).FirstOrDefault();
            }
            set
            {
                _status = value;
            }
        }
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
            }
        }
    }
}
