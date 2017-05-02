using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Status : DatabaseObject<Status>, IStatus
    {
        public byte StatusCode
        {
            get
            {
                return sts_cd;
            }
            set
            {
                sts_cd = value;
            }
        }

        public string Description
        {
            get
            {
                return sts_desc;
            }
            set
            {
                sts_desc = value;
            }
        }

        ICollection<IFailedSample> IStatus.FailedSamples
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

        ICollection<IProject> IStatus.Projects
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

        ICollection<IRequest> IStatus.Requests
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

        ICollection<IRequestItem> IStatus.RequestItems
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

        ICollection<ITask> IStatus.Tasks
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

        IStatus IStatus.Status
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
        public static bool operator ==(Status obj1, Status obj2)
        {
            if (object.ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (object.ReferenceEquals(obj1, null) ||
                object.ReferenceEquals(obj2, null))
            {
                return false;
            }
            return obj1.sts_cd == obj2.sts_cd;
        }
        public static bool operator !=(Status obj1, Status obj2)
        {
            return !(obj2 == obj1);
        }
        public override bool Equals(object obj)
        {
            if (obj is Status)
            {
                return (obj as Status) == this;
            }
            return false;
        }
    }
}
