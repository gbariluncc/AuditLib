using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Threading;

namespace Audits.Services
{
    public class MessengerService 
    {
        public object Display { get; set; }
        public long DisplayWidth { get; set; }
        public long DisplayHeight { get; set; }

         public void ShowMessage()
         {
             MessengerServiceViewModel vm = new MessengerServiceViewModel()
             {
                 Display = this.Display
             };

             MessengerWindow win = new MessengerWindow() { DataContext = vm,
                                                           Width = DisplayWidth,
                                                           Height = DisplayHeight};
             win.Show();
         }


    }
}
