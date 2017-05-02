using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IEmailAddress : IDatabaseObject<EmailAddress>
    {
        int ID { get; set; }
        int UserID { get; set; }
        string Address { get; set; }
        byte PositionID { get; set; }

    }
}
