using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IFacilityType : IDatabaseObject<FacilityType>
    {
        byte FacilityTypeID { get; set; }
        string Description { get; set; }

        ICollection<IDCIssue> DCIssues { get; set; }
        ICollection<IFacility> Facilities { get; set; }

        IFacilityType FacilityType { get; set; }
    }
}
