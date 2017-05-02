using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IEmailGroup : IDatabaseObject<EmailGroup>
    {
        int GroupID { get; set; }
        int EmailID { get; set; }
        byte EmailTypeID { get; set; }

        IEmailAddress EmailAddress { get; }
    }
}
