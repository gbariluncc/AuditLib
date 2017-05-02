using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class User
    {
        private HashSet<Account> _accounts;
        private HashSet<Audit> _audits;
        private Auditor _auditor;
        private Role _role;
        private HashSet<Dimension> _dimensions;
        private HashSet<Task> _tasks;

        public User()
        {
        }

        public int usr_id { get; set; }
        public string usr_fname { get; set; }
        public string usr_lname { get; set; }
        public string usr_email { get; set; }
        public string usr_pclogon { get; set; }
        public short fac_num { get; set; }
        public byte role_id { get; set; }

       public virtual ICollection<Account> Accounts {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new Account().Where("usr_id=" + usr_id).ToHashSet();
                }
                return _accounts;
            }
            set
            {
                _accounts = (HashSet<Account>)value;
            }
        }
        public virtual Auditor Auditor 
        {
            get
            {
                if (_auditor == null)
                {
                    //Not currently implimented - need a repository
                }
                return _auditor;
            }
            set { _auditor = value; }
        }
        public virtual ICollection<Dimension> Dimensions 
        {
            get
            {
                if (_dimensions == null)
                {
                    _dimensions = new Dimension().Where("usr_id=" + usr_id).ToHashSet();
                }
                return _dimensions;
            }
            set
            {
                _dimensions = (HashSet<Dimension>)value;
            } 
        }
        public virtual Role Role 
        {
            get
            {
                if (_role == null)
                {
                    _role = new Role().Where("role_id=" + role_id).SingleOrDefault();
                }
                return _role;
            }
            set
            {
                _role = value;
            }
        }
        public virtual ICollection<Audit> Audits
        {
            get
            {
                if (_audits == null)
                {
                    _audits = new Audit().Where("usr_id=" + usr_id).ToHashSet();
                }
                return _audits;
            }
        }
        public virtual ICollection<Task> Tasks 
        {
            get
            {
                 return new Task().Where("usr_id=" + usr_id).ToHashSet();
            }
            set
            {
                _tasks = (HashSet<Task>)value;
            }
        }
    }
}
