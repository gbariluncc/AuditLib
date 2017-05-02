using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IPackagingLevel : IDatabaseObject<PackagingLevel>
    {
        byte LevelID { get; set; }
        string LevelDescription { get; set; }
        string DMSPrefix { get; set; }
        bool DMSAvailable { get; set; }
        string AltDescription { get; set; }
        bool HasQty { get; set; }

        ICollection<IDimension> Dimensions { get; set; }
        ICollection<IPicture> Pictures { get; set; }

        IPackagingLevel PackagingLevel { get; set; }
    }
}
