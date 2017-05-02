using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Audits.Display
{
    public interface INotifyAction
    {
        ICommand NotificationEvent { set; }
    }
}
