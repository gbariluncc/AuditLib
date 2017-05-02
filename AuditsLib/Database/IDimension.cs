using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IDimension : IDatabaseObject<Dimension>
    {
        long DimensionID { get; set; }
        long RequestItemID { get; set; }
        byte LevelID { get; set; }
        double Length { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Weight { get; set; }
        int Quantity { get; set; }
        DateTime AddDate { get; set; }
        byte CategoryID { get; set; }
        int UserID { get; set; }
        int? StackHeight { get; set; }
        double? PrintedWeight { get; set; }
        string Comments { get; set; }

        ICategory Category { get; set; }
        IPackagingLevel PackagingLevel { get; set; }
        IRequestItem RequestItem { get; set; }
        IUser User { get; set; }

        IDimension Dimension { get; set; }
    }
}
