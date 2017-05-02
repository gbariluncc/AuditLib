using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Audits.Infastructure
{
    public class Navigator
    {
        private static Frame _frame;
        private static bool _showNavUI = false;
        private static Navigator _nav = new Navigator();

        private Navigator() { }

        public NavigationService NavService
        {
            get
            {
                return _frame.NavigationService;
            }
        }
        public static Navigator GetInstance()
        {
            return _nav;
        }

        public Frame ConentFrame
        {
            get
            {
                return _frame;
            }
            set
            {
                _frame = value;
            }
        }
        public System.Windows.Navigation.NavigationUIVisibility ShowNavUI
        {
            get { return _frame.NavigationUIVisibility; }
            set { _frame.NavigationUIVisibility = value; }
        }
        public bool Navigate(string type)
        {
            return _frame.Navigate(Type.GetType(type));
        }
        public bool Navigate(string type, object parameter)
        {
            return _frame.Navigate(Type.GetType(type), parameter);
        }
        public bool Navigate(object page)
        {
            return _frame.Navigate(page);
        }
        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }
        public void Clear()
        {

            while (_frame.NavigationService.CanGoBack)
            {
                _frame.NavigationService.RemoveBackEntry();
            }

            _frame.Navigate(new PageFunction<string>() { RemoveFromJournal = true });
        }
    }
}
