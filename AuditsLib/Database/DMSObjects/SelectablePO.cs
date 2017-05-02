using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Audits.Database.DMSObjects
{
    public class SelectablePO : PODecorator
    {
        private bool _isSelected;

        public SelectablePO(IPO po)
            : base(po)
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName]string PropertyName = "")
        {
            var changed = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (changed)
            {
                backingField = value;
                this.OnPropertyChanged(PropertyName);
            }
            return changed;
        }
        public bool IsSelected 
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
        public string ItemCombosString
        {
            get
            {
                if (Root is POwithItemCombo)
                {
                    return (Root as POwithItemCombo).ItemCombosString;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
