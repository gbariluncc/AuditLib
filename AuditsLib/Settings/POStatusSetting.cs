using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows;
using System.Media;
using System.Windows.Media;

namespace Audits.Settings
{
    public class POStatusSetting : INotifyPropertyChanged
    {
        private string _name;
        private string _notColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public POStatusSetting() { }

        public POStatusSetting(string name, string notColor) { this.Name = name; this.NotificationColor = notColor; }
        public void OnPropertyChanged([CallerMemberName]string PropertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string NotificationColor
        {
            get { return _notColor; }
            set { _notColor = value; OnPropertyChanged(); }
        }
    }
}
