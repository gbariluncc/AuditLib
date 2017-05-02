using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AuditControls.Model;

namespace AuditControls.Controls
{
    /// <summary>
    /// Interaction logic for CorkBoard.xaml
    /// </summary>
    public partial class CorkBoard : UserControl
    {
        private static DependencyProperty OutputPathProperty = DependencyProperty.Register("OutputPath", typeof(string), typeof(CorkBoard),
            new PropertyMetadata(OnSetOutputPath));

        public CorkBoard()
        {
            InitializeComponent();
        }

        public string OutputPath
        {
            get { return GetValue(OutputPathProperty) as string; }
            set { SetValue(OutputPathProperty, value); }
        }

        private static void OnSetOutputPath(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string)
            {
                CorkBoard source = (CorkBoard)d;
                source.SetOutputPath(e.NewValue.ToString(), source);
            }
        }

        private void SetOutputPath(string value, CorkBoard source)
        {
            CorkboardViewModel vm = (CorkboardViewModel)source.RootElement.DataContext;
            vm.OutputFilePath = value;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            CorkboardViewModel vm = (CorkboardViewModel)(sender as CorkBoard).RootElement.DataContext;
            vm.SaveFile();
        }
    }
}
