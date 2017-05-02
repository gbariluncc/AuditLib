using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class EmailAddress
    {
        public int email_id { get; set; }
        public int usr_id { get; set; }
        public string email_addr { get; set; }
        public byte pos_id { get; set; }

    }
}
