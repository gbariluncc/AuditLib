using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IHold : IDatabaseObject<Hold>
    {
        int HoldID { get; set; }
        DateTime HoldDate { get; set; }
        DateTime ReleaseDate { get; set; }
        int PONumber { get; set; }
        byte ReasonCode { get; set; }
        string HoldComments { get; set; }
        DateTime HoldExpiration { get; set; }

        IHoldReason HoldReason { get; }
    }
}
