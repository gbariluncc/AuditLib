using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class EmailGroup : DatabaseObject<EmailGroup>, IEmailGroup
    {
        public int GroupID
        {
            get
            {
                return grp_id;
            }
            set
            {
                grp_id = value;
            }
        }

        public int EmailID
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

        public byte EmailTypeID
        {
            get
            {
                return email_typ_id;
            }
            set
            {
                email_typ_id = value;
            }
        }
    }
}
