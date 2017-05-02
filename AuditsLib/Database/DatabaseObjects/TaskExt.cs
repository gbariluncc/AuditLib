using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Task : DatabaseObject<Task>, ITask, IComparable, IEquatable<Task>
    {
        public long TaskID
        {
            get
            {
                return task_id;
            }
            set
            {
                task_id = value;
            }
        }

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
        public bool IsNew { get { return is_new; } set { is_new = value; } }
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

        public DateTime AssignDate
        {
            get
            {
                return task_assgn_dt;
            }
            set
            {
                task_assgn_dt = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return task_due_dt;
            }
            set
            {
                task_due_dt = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return task_upd_dt;
            }
            set
            {
                task_upd_dt = value;
            }
        }

        public byte PriorityLevel
        {
            get
            {
                return prior_lvl;
            }
            set
            {
                prior_lvl = value;
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
                if (sts_cd != Status.StatusCode)
                {
                    Status = DBContext.Instance.Status.GetSingle(s => s.sts_cd == StatusCode);
                }
            }
        }

        public string Comments
        {
            get
            {
                return task_comm;
            }
            set
            {
                task_comm = value;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return (Priority != null
                        && Request != null
                        && Status != null
                        && User != null);
            }
        }
        public static bool operator ==(Task t1, Task t2)
        {
            if (object.ReferenceEquals(t1, t2))
            {
                return true;
            }
            if(object.ReferenceEquals(t1,null)||
                object.ReferenceEquals(t2, null))
            {
                return false;
            }

            return t1.TaskID == t2.TaskID;
        }
        public static bool operator !=(Task t1, Task t2)
        {
            return !(t1 == t2);
        }
        public bool Equals(Task other)
        {
            if (other is Task)
            {
                return this == (other as Task);
            }
            return false;
        }

        IPriority ITask.Priority
        {
            get
            {
                return Priority;
            }
            set
            {
                Priority = (Priority)value;
            }
        }

        IRequest ITask.Request
        {
            get
            {
                return Request;
            }
            set
            {
                Request = (Request)value;
            }
        }

        IStatus ITask.Status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = (Status)value;
                if (Status.StatusCode != this.StatusCode)
                {
                    this.StatusCode = Status.StatusCode;
                }
            }
        }

        IUser ITask.User
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

        ITask ITask.Task
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

        public int CompareTo(object obj)
        {
            if (obj is Task || obj is ITask)
            {
                return Compare((obj as ITask));
            }
            else { throw new ArgumentException("Object is not a Task."); }
        }
        private int Compare(ITask t)
        {
            ITask temp = this;

            if (temp.TaskID == t.TaskID)
            {
                return 0;
            }
            else if (t.TaskID > temp.TaskID)
            {
                return -1;
            }
            else{ return 1; }
        }

        public bool Equals(ITask other)
        {
            return this.TaskID == other.TaskID;
        }
        public override bool Equals(object obj)
        {
            if (obj is Task)
            {
                return (obj as Task) == this;
            }
            return false;
        }
    }
}
