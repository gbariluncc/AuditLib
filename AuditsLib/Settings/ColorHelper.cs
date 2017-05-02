using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Media;
using System.Windows.Media;

namespace Audits.Settings
{
    public static class ColorHelper
    {
        public static IEnumerable<string> GetColorNames()
        {
            foreach (PropertyInfo p in typeof(Colors).GetProperties()) { yield return p.Name; }
        }
    }
}
