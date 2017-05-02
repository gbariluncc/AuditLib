using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Role : DatabaseObject<Role>, IRole
    {
        public byte RoleID
        {
            get
            {
                return role_id;
            }
            set
            {
                role_id = value;
            }
        }

        public string Description
        {
            get
            {
                return role_desc;
            }
            set
            {
                role_desc = value;
            }
        }

        public byte AccessLevel
        {
            get
            {
                return role_acc_lvl;
            }
            set
            {
                role_acc_lvl = value;
            }
        }

        ICollection<IUser> IRole.Users
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IUser, User>(Users);
            }
            set
            {
                Users = InterfaceConverter.ConvertToCollection<User, IUser>(value);
            }
        }

        IRole IRole.Role
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

        public static bool operator ==(Role obj1, Role obj2)
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
            return obj1.role_id == obj2.role_id;
        }
        public static bool operator !=(Role obj1, Role obj2)
        {
            return !(obj2 == obj1);
        }
        public override bool Equals(object obj)
        {
            if (obj is Role)
            {
                return (obj as Role) == this;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return role_id.GetHashCode();
        }
    }
}
