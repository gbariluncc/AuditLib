using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IEmailType : IDatabaseObject<EmailType>
    {
        byte TypeID { get; set; }
        string Text { get; set; }
    }
}
