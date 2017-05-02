using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using System.Windows.Media;

namespace Audits.Database
{
    public interface ISource : IDatabaseObject<Source>
    {
        byte SourceID { get; set; }
        string Description { get; set; }
        bool IsSelected { get; set; }
        Geometry Icon { get; }

        ICollection<IProject> Projects { get; set; }
        ISource Source { get; set; }
    }
}
