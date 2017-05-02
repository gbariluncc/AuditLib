using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Interop
{
    public interface ISheetColumn
    {
        long ColumnID { get; set; }
        long SheetID { get; set; }
        string Name { get; set; }
        bool Import { get; set; }
        long ColumnNumber { get; set; }
        string ColumnLetter { get; set; }
        string TableMap { get; set; }
        long SequenceID { get; set; }
        bool ObjSkip { get; set; }

        ISheet Sheet { get; set; }

    }
}
