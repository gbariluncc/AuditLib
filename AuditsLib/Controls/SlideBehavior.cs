using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Infastructure.Commands;

namespace AuditControls.Controls.Commands
{
    class SliderBehavior : IClickBehavior
    {
        private DelegateCommand _command;
        private IClickBehavior _behavior;

        public SliderBehavior(IClickBehavior behavior, DelegateCommand command)
        {
            _command = command;
            _behavior = behavior;
        }

        public void Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_command != null) _command.Execute(null);
            if (_behavior != null) _behavior.Click(sender, e);
        }
    }
}

