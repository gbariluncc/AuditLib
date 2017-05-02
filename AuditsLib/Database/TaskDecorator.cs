using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;
using Audits;
using Audits.Infastructure;
using System.Runtime.CompilerServices;

namespace Audits.Database
{
    public abstract class TaskDecorator : ViewBase, ITask, IEquatable<ITask>
    {
        private ITask _task;

        public TaskDecorator(ITask task)
        {
            _task = task;
        }
        public bool IsNew
        {
            get { return _task.IsNew; }
            set { _task.IsNew = value; }
        }
        public long TaskID
        {
            get
            {
                return _task.TaskID;
            }
            set
            {
                _task.TaskID = value; OnPropertyChanged();
            }
        }
        public bool NeedsToSave
        {
            get { return _task.NeedsToSave; }
            set { _task.NeedsToSave = value; }
        }
        public long RequestID
        {
            get
            {
                return _task.RequestID;
            }
            set
            {
                _task.RequestID = value; OnPropertyChanged();
            }
        }

        public int UserID
        {
            get
            {
                return _task.UserID;
            }
            set
            {
                _task.UserID = value; OnPropertyChanged();
            }
        }

        public DateTime AssignDate
        {
            get
            {
                return _task.AssignDate;
            }
            set
            {
                _task.AssignDate = value; OnPropertyChanged();
            }
        }

        public DateTime DueDate
        {
            get
            {
                return _task.DueDate;
            }
            set
            {
                _task.DueDate = value; OnPropertyChanged();
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return _task.UpdateDate;
            }
            set
            {
                _task.UpdateDate = value; OnPropertyChanged();
            }
        }

        public byte PriorityLevel
        {
            get
            {
                return _task.PriorityLevel;
            }
            set
            {
                _task.PriorityLevel = value; OnPropertyChanged();
            }
        }

        public byte StatusCode
        {
            get
            {
                return _task.StatusCode;
            }
            set
            {
                _task.StatusCode = value; OnPropertyChanged();
            }
        }

        public string Comments
        {
            get
            {
                return _task.Comments;
            }
            set
            {
                _task.Comments = value; OnPropertyChanged();
            }
        }

        public IPriority Priority
        {
            get
            {
                return _task.Priority;
            }
            set
            {
                _task.Priority = value;
            }
        }

        public IRequest Request
        {
            get
            {
                return _task.Request;
            }
            set
            {
                _task.Request = value; OnPropertyChanged();
            }
        }

        public IStatus Status
        {
            get
            {
                return _task.Status;
            }
            set
            {
                _task.Status = value; OnPropertyChanged();
            }
        }

        public IUser User
        {
            get
            {
                return _task.User;
            }
            set
            {
                _task.User = value; OnPropertyChanged();
            }
        }

        public ITask Task
        {
            get
            {
                return _task.Task;
            }
            set
            {
                
            }
        }

        public virtual void Update()
        {
             _task.Update();
        }

        public virtual void Add()
        {
            _task.Add();
        }

        public virtual void Delete()
        {
            _task.Delete();
        }

        public bool IsLoaded
        {
            get { return _task.IsLoaded; }
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

        public void Add(bool addAll = false, ProgressReporter pg = null)
        {
            _task.Add(addAll,pg);
        }
        public void AddAsync(bool addAll = false, ProgressReporter pg = null)
        {
            _task.AddAsync(addAll,pg);
        }

        public bool Equals(Task other)
        {
            return _task.Equals(other);
        }

        public bool Equals(ITask other)
        {
            return _task.Equals(other);
        }
    }
}
