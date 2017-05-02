using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class EmailType
    {
        byte email_typ_id { get; set; }
        string email_typ_txt { get; set; }
    }
}
