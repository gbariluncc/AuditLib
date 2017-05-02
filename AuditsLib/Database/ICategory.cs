using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface ICategory : IDatabaseObject<Category>
    {
        byte CategoryID { get; set; }
        string CategoryDescription { get; set; }
        byte CategoryGroup { get; set; }
        byte? CategorySummaryGroup { get; set; }

        ICollection<IAudit> Audits { get; set; }
        ICollection<ICategory> SubCategories { get; set; }
        ICategory ParentCategory { get; set; }
        ICollection<IDimension> Dimensions { get; set; }
        ICollection<IRequest> Requests { get; set; }

        ICategory Category { get; set; }
    }
}
