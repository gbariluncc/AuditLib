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

namespace AuditControls.Controls
{
    /// <summary>
    /// Interaction logic for RequestCard.xaml
    /// </summary>
    public partial class RequestCard : UserControl
    {
        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(RequestCard));
        public static DependencyProperty RSourceProperty = DependencyProperty.Register("RSource", typeof(string), typeof(RequestCard));
        public static DependencyProperty InstructionsProperty = DependencyProperty.Register("Instructions", typeof(string), typeof(RequestCard));
        public static DependencyProperty PriorityProperty = DependencyProperty.Register("Priority", typeof(string), typeof(RequestCard));
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(RequestCard));
        public static DependencyProperty DueDateProperty = DependencyProperty.Register("DueDate", typeof(string), typeof(RequestCard));
        public static DependencyProperty ClickCommandProperty = DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(RequestCard));
        public static DependencyProperty IconToolTipProperty = DependencyProperty.Register("IconToolTip", typeof(string), typeof(RequestCard));
        public static DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(RequestCard));
        public static DependencyProperty IsLoadingProperty = DependencyProperty.Register("IsLoading", typeof(bool), typeof(RequestCard));
        public static DependencyProperty IsNewProperty = DependencyProperty.Register("IsNew", typeof(bool), typeof(RequestCard));
        public static DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(RequestCard));

        public RequestCard()
        {
            InitializeComponent();
            this.ClickSurface.DataContext = this;
        }
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }
        public bool IsNew
        {
            get { return (bool)GetValue(IsNewProperty); }
            set { SetValue(IsNewProperty, value); }
        }
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public string DueDate
        {
            get { return (string)GetValue(DueDateProperty); }
            set { SetValue(DueDateProperty, value); }
        }
        public string IconToolTip
        {
            get { return (string)GetValue(IconToolTipProperty); }
            set { SetValue(IconToolTipProperty, value); }
        }
        public string Status
        {
            get { return GetValue(StatusProperty) as string; }
            set { SetValue(StatusProperty, value); }
        }
        public ICommand ClickCommand
        {
            get
            {
                return (ICommand)GetValue(ClickCommandProperty);
            }
            set
            {
                SetValue(ClickCommandProperty, value);
            }
        }
        public string RSource
        {
            get { return (string)GetValue(RSourceProperty); }
            set { SetValue(RSourceProperty, value); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public string Priority
        {
            get { return (string)GetValue(PriorityProperty); }
            set { SetValue(PriorityProperty, value); }
        }
        public string Instructions
        {
            get { return (string)GetValue(InstructionsProperty); }
            set { SetValue(InstructionsProperty, value); }
        }

    }
}
