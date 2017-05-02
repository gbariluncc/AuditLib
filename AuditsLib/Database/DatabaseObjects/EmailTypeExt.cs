using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class EmailType : DatabaseObject<EmailType>, IEmailType
    {

        public byte TypeID
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

        public string Text
        {
            get
            {
                return email_typ_txt;
            }
            set
            {
                email_typ_txt = value;
            }
        }
    }
}
