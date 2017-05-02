using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class User : DatabaseObject<User>, IUser
    {

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

        public string FirstName
        {
            get
            {
                return usr_fname;
            }
            set
            {
                usr_fname = value;
            }
        }

        public string LastName
        {
            get
            {
                return usr_lname;
            }
            set
            {
                usr_lname = value;
            }
        }

        public string Email
        {
            get
            {
                return usr_email;
            }
            set
            {
                usr_email = value;
            }
        }

        public string PCLogon
        {
            get
            {
                return usr_pclogon;
            }
            set
            {
                usr_pclogon = value;
            }
        }

        public short FacilityNumber
        {
            get
            {
                return fac_num;
            }
            set
            {
                fac_num = value;
            }
        }

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




        ICollection<IAccount> IUser.Accounts
        {
            get
            {
                return Accounts.ToHashSet<IAccount>();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        ICollection<IAudit> IUser.Audits
        {
            get
            {
                return Audits.ToHashSet<IAudit>();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IAuditor IUser.Auditor
        {
            get
            {
                return Auditor;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        ICollection<IDimension> IUser.Dimensions
        {
            get
            {
                return Dimensions.ToHashSet<IDimension>();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IRole IUser.Role
        {
            get
            {
                return Role;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        ICollection<ITask> IUser.Tasks
        {
            get
            {
                return Tasks.ToHashSet<ITask>();
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
        public static bool operator ==(User obj1, User obj2)
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
            return obj1.usr_id == obj2.usr_id;
        }
        public static bool operator !=(User obj1, User obj2)
        {
            return !(obj2 == obj1);
        }
        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                return (obj as User) == this;
            }
            return false;
        }
    }
}
