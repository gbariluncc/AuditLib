using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Audits.Database;

namespace Audits.Display
{
    public interface IDisplaySource : ISource
    {
        string Icon { get; set; }
        string MonochromeIcon { get; set; }
        ICommand Filter { get; set; }
    }
}
