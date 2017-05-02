using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Audits.Database;

namespace Audits.Display
{
    public interface IDisplayTask : ITask
    {
        ISource Source { get; set; }
        ICommand DetailClick { get; set; }
        ICollection<ICategory> Categories { get; }
        long ID { get; }
        string Icon { get; set; }
        bool IsLoading { get; set; }
    }
}
