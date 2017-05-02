using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits;

namespace Audits.Database.DatabaseObjects
{
    public partial class EmailGroup
    {
        private IEmailAddress _emailAddress;

        public int email_id { get; set; }
        public int grp_id { get; set; }
        public byte email_typ_id { get; set; }
        
        public IEmailAddress EmailAddress
        {
            get 
            {
                if(_emailAddress == null)
                    _emailAddress = new EmailAddress().Where("email_id={0}".Format(email_id)).FirstOrDefault();

                return _emailAddress;
            }
        }
    }
}
