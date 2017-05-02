using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Audits;
using Audits.Database;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public abstract class RoleDecorator : IRole
    {
        private IRole _role;
        public RoleDecorator(IRole role)
        {
            _role = role;
        }

        public byte RoleID
        {
            get
            {
                return _role.RoleID;
            }
            set
            {
                _role.RoleID = value;
            }
        }

        public string Description
        {
            get
            {
                return _role.Description;
            }
            set
            {
                _role.Description = value;
            }
        }

        public byte AccessLevel
        {
            get
            {
                return _role.AccessLevel;
            }
            set
            {
                _role.AccessLevel = value;
            }
        }

        public ICollection<IUser> Users
        {
            get
            {
                return _role.Users;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IRole Role
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

        public virtual void Update()
        {
            _role.Update();
        }

        public virtual void Add(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _role.Add(addAll, pg);
        }

        public virtual void Delete()
        {
            _role.Delete();
        }

        public virtual void AddAsync(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _role.AddAsync(addAll, pg);
        }
        public static bool operator ==(RoleDecorator obj1, RoleDecorator obj2)
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
            return obj1.RoleID == obj2.RoleID;
        }
        public static bool operator !=(RoleDecorator obj1, RoleDecorator obj2)
        {
            return !(obj2 == obj1);
        }
        public override bool Equals(object obj)
        {
            if (obj is RoleDecorator || obj is Role)
            {
                return (obj as IRole).RoleID == this.RoleID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return _role.GetHashCode();
        }
        public bool NeedsToSave
        {
            get
            {
                return _role.NeedsToSave;
            }
            set
            {
                _role.NeedsToSave = value;
            }
        }
        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            _role.OnPropertyChanged(propName);
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
    }
}
