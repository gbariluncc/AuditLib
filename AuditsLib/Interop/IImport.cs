using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;

namespace Audits.Interop
{
    public interface IImport<T> : IDatabaseObject<Import<T>> where T : class, new()
    {
        long ImportID { get; set; }
        byte ImportMonth { get; set; }
        int ImportYear { get; set; }
        int ImportWeek { get; set; }
        DateTime AddDate { get; set; }
        DateTime UpdateDate { get; set; }
        int SheetID { get; set; }
        string FilePath { get; set; }

        ISheet Sheet { get; set; }
        ICollection<T> ImportData { get; set; }
    }
}
