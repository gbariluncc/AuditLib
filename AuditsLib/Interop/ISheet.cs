using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Interop
{
    public interface ISheet
    {
        long ID { get; set; }
        string Name { get; set; }
        string DefaultDirectory { get; set; }
        long Number { get; set; }
        string DataTable { get; set; }
        long DataRowStart { get; set; }

        ICollection<ISheetColumn> SheetColumns { get; set; }

    }
}
