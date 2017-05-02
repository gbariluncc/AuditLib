using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Audits.Settings
{
    [Serializable]
    public class POStatusSettings
    {
        public ObservableCollection<POStatusSetting> Settings { get; set; }
        public ObservableCollection<string> NoteColors { get; set; }
        public POStatusSettings()
        {
            Settings = new ObservableCollection<POStatusSetting>();
            NoteColors = new ObservableCollection<string>();
            GetColors();
        }

        public POStatusSettings(bool isNew)
            : this()
        {
            Settings.Add(new POStatusSetting("In Doors", "Red"));
            Settings.Add(new POStatusSetting("On Yard", string.Empty));
            Settings.Add(new POStatusSetting("In Receiving", string.Empty));
            Settings.Add(new POStatusSetting("Not Arrived", string.Empty));
            Settings.Add(new POStatusSetting("Received", "Blue"));
            Settings.Add(new POStatusSetting("On Hold", string.Empty));
            Settings.Add(new POStatusSetting("Closed", string.Empty));
        }

        private void GetColors()
        {
            IEnumerable<string> c = ColorHelper.GetColorNames();
            foreach (string clr in c)
            {
                NoteColors.Add(clr);
            }
        }
    }
}
