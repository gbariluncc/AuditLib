using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IFacility : IDatabaseObject<Facility>
    {
        short FacilityNumber { get; set; }
        string StringID { get; set; }
        string Name { get; set; }
        byte FacilityTypeID { get; set; }
        string ConnectionString { get; set; }
        bool InUse { get; set; }

        IFacilityType FacilityType { get; set; }

        IFacility Facility { get; set; }
    }
}
