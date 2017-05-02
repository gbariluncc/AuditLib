using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using Audits.Database;
using Audits.Helpers;

namespace Audits.Display
{
    public class DisplaySource : SourceDecorator, IDisplaySource
    {
        public DisplaySource(ISource source)
            : base(source)
        {
            Icon = SourceTypeHelper.GetIcon(this);
            MonochromeIcon = SourceTypeHelper.GetMonochromeIcon(this);
        }

        public string Icon
        {
            get;
            set;
        }

        public string MonochromeIcon
        {
            get;
            set;
        }

        public System.Windows.Input.ICommand Filter
        {
            get;
            set;
        }
    }
}
