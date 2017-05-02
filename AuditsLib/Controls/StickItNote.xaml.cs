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
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace AuditControls.Controls
{
    /// <summary>
    /// Interaction logic for StickItNote.xaml
    /// </summary>
    public partial class StickItNote : UserControl, INotifyPropertyChanged
    {
        private Cursor _cursor;
        public static DependencyProperty NoteTextProperty = DependencyProperty.Register("NoteText", typeof(string), typeof(StickItNote));
        public static DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(StickItNote));
        public static DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(StickItNote));
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public ICommand CloseCommand
        {
            get { return GetValue(CloseCommandProperty) as ICommand; }
            set { SetValue(CloseCommandProperty, value); }
        }
        public string Date
        {
            get { return GetValue(DateProperty) as string; }
            set { SetValue(DateProperty, value); }
        }

        public string NoteText
        {
            get
            {
                return GetValue(NoteTextProperty) as string;
            }
            set
            {
                SetValue(NoteTextProperty, value);
            }
        }
        public StickItNote()
        {
            InitializeComponent();
            ControlBorder.DataContext = this;
        }
        private void OnResizeThumbDragStarted(object sender, DragStartedEventArgs e)
        {
            _cursor = Cursor;
            Cursor = Cursors.SizeNWSE;
        }

        private void OnResizeThumbDragCompleted(object sender, DragCompletedEventArgs e)
        {
            Cursor = _cursor;
        }

        private void OnResizeThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double yAdjust = sizableContent.Height + e.VerticalChange;
            double xAdjust = sizableContent.Width + e.HorizontalChange;

            //make sure not to resize to negative width or heigth            
            xAdjust = (sizableContent.ActualWidth + xAdjust) > sizableContent.MinWidth ? xAdjust : sizableContent.MinWidth;
            yAdjust = (sizableContent.ActualHeight + yAdjust) > sizableContent.MinHeight ? yAdjust : sizableContent.MinHeight;

            sizableContent.Width = xAdjust;
            sizableContent.Height = yAdjust;
        }
    }
}