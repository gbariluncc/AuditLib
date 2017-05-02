using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Priority : DatabaseObject<Priority>, IPriority
    {
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

        public string Description
        {
            get
            {
                return prior_desc;
            }
            set
            {
                prior_desc = value;
            }
        }

        public byte DaysToComplete
        {
            get
            {
                return prior_days_to_comp;
            }
            set
            {
                prior_days_to_comp = value;
            }
        }

        ICollection<ITask> IPriority.Tasks
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<ITask, Task>(Tasks);
            }
            set
            {
                Tasks = InterfaceConverter.ConvertToCollection<Task, ITask>(value);
            }
        }

        IPriority IPriority.Priority
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
        public static bool operator ==(Priority p1, Priority p2)
        {
            if (object.ReferenceEquals(p1, p2))
            {
                return true;
            }
            if(object.ReferenceEquals(p1,null)||
                object.ReferenceEquals(p2, null))
            {
                return false;
            }
            return p1.prior_lvl == p2.prior_lvl;
        }
        public static bool operator !=(Priority p1, Priority p2)
        {
            return !(p1 == p2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Priority)
            {
                return (obj as Priority) == this;
            }
            return false;
        }

    }
}
