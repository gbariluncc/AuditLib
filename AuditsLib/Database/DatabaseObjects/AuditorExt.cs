using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Auditor : DatabaseObject<Auditor>, IAuditor
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

        public bool GetsFailedSamples
        {
            get
            {
                return aud_gets_failsam;
            }
            set
            {
                aud_gets_failsam = value;
            }
        }

        IUser IAuditor.User
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

        IAuditor IAuditor.Auditor
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
    }
}
