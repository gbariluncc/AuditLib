using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class EmailAddress : DatabaseObject<EmailAddress>, IEmailAddress
    {
        public int ID
        {
            get
            {
                return email_id;
            }
            set
            {
                email_id = value;
            }
        }

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

        public string Address
        {
            get
            {
                return email_addr;
            }
            set
            {
                email_addr = value;
            }
        }

        public byte PositionID
        {
            get
            {
                return pos_id;
            }
            set
            {
                pos_id = value;
            }
        }
    }
}
