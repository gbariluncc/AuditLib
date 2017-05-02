using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Interop
{
    public interface IImportable
    {
        long import_id { get; set; }
    }
}
