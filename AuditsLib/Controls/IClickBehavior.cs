using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditControls.Controls
{
    public interface IClickBehavior
    {
        void Click(object sender, System.Windows.RoutedEventArgs e);
    }
}
