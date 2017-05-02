using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;
using Audits.Infastructure.Commands;

namespace Audits.Services
{
    class MessengerServiceViewModel : ViewBase
    {
        private object _display;
        private long _wid;
        private long _hgt;

        public object Display
        {
            get { return _display; }
            set
            {
                SetProperty(ref _display, value);
            }
        }
        public long DisplayWidth { get { return _wid; } set{ SetProperty(ref _wid,value); } }
        public long DisplayHeight { get { return _hgt; } set { SetProperty(ref _hgt, value); } }
        public ICommand Close
        {
            get
            {
                Action<object> closeTarget = delegate(object o) { closeExecuted(o); };
                return new DelegateCommand(closeTarget, param => true);
            }
        }
        private void closeExecuted(object o)
        {
            if (o is Window)
            {
                (o as Window).Close();
            }
        }
    }
}
