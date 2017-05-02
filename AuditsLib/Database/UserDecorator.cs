using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public abstract class UserDecorator : ViewBase, IUser
    {
        private IUser _user;

        public UserDecorator(IUser user)
        {
            _user = user;
        }

        public int UserID
        {
            get
            {
                return _user.UserID;
            }
            set
            {
                _user.UserID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _user.FirstName;
            }
            set
            {
                _user.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _user.LastName;
            }
            set
            {
                _user.LastName = value;
            }
        }

        public string Email
        {
            get
            {
                return _user.Email;
            }
            set
            {
                _user.Email = value;
            }
        }

        public string PCLogon
        {
            get
            {
                return _user.PCLogon;
            }
            set
            {
                _user.PCLogon = value;
            }
        }

        public short FacilityNumber
        {
            get
            {
                return _user.FacilityNumber;
            }
            set
            {
                _user.FacilityNumber = value;
            }
        }

        public byte RoleID
        {
            get
            {
                return _user.RoleID;
            }
            set
            {
                _user.RoleID = value;
            }
        }

        public ICollection<IAccount> Accounts
        {
            get
            {
                return _user.Accounts;
            }
            set
            {
                _user.Accounts = value;
            }
        }

        public ICollection<IAudit> Audits
        {
            get
            {
                return _user.Audits;
            }
            set
            {
                _user.Audits = value;
            }
        }

        public IAuditor Auditor
        {
            get
            {
                return _user.Auditor;
            }
            set
            {
                _user.Auditor = value;
            }
        }

        public ICollection<IDimension> Dimensions
        {
            get
            {
                return _user.Dimensions;
            }
            set
            {
                _user.Dimensions = value;
            }
        }

        public IRole Role
        {
            get
            {
                return _user.Role;
            }
            set
            {
                _user.Role = value;
            }
        }

        public ICollection<ITask> Tasks
        {
            get
            {
                return _user.Tasks;
            }
            set
            {
                _user.Tasks = value;
            }
        }

        public virtual void Update()
        {
            _user.Update();
        }

        public virtual void Add(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _user.Add(addAll, pg);
        }

        public virtual void Delete()
        {
            _user.Delete();
        }

        public virtual void AddAsync(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _user.AddAsync(addAll, pg);
        }

        public virtual bool NeedsToSave
        {
            get
            {
                return _user.NeedsToSave;
            }
            set
            {
                _user.NeedsToSave = value;
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
        public static bool operator ==(UserDecorator obj1, UserDecorator obj2)
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
            return obj1.UserID == obj2.UserID;
        }
        public static bool operator !=(UserDecorator obj1, UserDecorator obj2)
        {
            return !(obj2 == obj1);
        }
        public override bool Equals(object obj)
        {
            if (obj is UserDecorator)
            {
                return (obj as UserDecorator) == this;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return _user.GetHashCode();
        }
        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            _user.OnPropertyChanged(propName);
        }
    }
}
