using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IRating : IDatabaseObject<Rating>
    {
        byte RatingID { get; set; }
        string Description { get; set; }
        string ShortDescription { get; set; }

        ICollection<IAudit> Audits { get; set; }
        IRating Rating { get; set; }
    }
}
