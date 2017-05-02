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
using System.Windows.Media.Animation;

namespace AuditControls.Controls
{
    /// <summary>
    /// Interaction logic for Switcher.xaml
    /// </summary>
    public partial class Switcher : UserControl
    {
        private bool _toolShow = false;

        //Dependencies
        public static DependencyProperty ToolFrameWidthProperty = DependencyProperty.Register("ToolFrameWidth", typeof(double), typeof(Switcher));
        public static DependencyProperty NavigatorProperty = DependencyProperty.Register("Navigator", typeof(NavigationService), typeof(Switcher));
        public static DependencyProperty ToolFrameProperty = DependencyProperty.Register("ToolFrame", typeof(Frame), typeof(Switcher));
        public static DependencyProperty MenuProperty = DependencyProperty.Register("Menu", typeof(Menu), typeof(Switcher));
        public static DependencyProperty ContentFrameProperty = DependencyProperty.Register("ContentFrame", typeof(Frame), typeof(Switcher));
        public static DependencyProperty ToolPageProperty = DependencyProperty.Register("ToolPage", typeof(Page), typeof(Switcher));
        public static DependencyProperty MainPageProperty = DependencyProperty.Register("MainPage", typeof(Page), typeof(Switcher));
        public static DependencyProperty MainPageObjectProperty = DependencyProperty.RegisterAttached("MainPageObject", typeof(object), typeof(Switcher),
            new UIPropertyMetadata((object)null, OnMainPageObjectChange));

        public Page ToolPage
        {
            get { return (Page)GetValue(ToolPageProperty); }
            set { SetValue(ToolPageProperty, value); }
        }
        public Page MainPage
        {
            get { return (Page)GetValue(MainPageProperty); }
            set { SetValue(MainPageProperty, value); this.ContentFrame.Navigate(value); }
        }
        public object MainPageObject
        {
            get { return (object)GetValue(MainPageObjectProperty); }
            set { SetValue(MainPageObjectProperty, value); }
        }
        public double ToolFrameWidth
        {
            get { return (double)GetValue(ToolFrameWidthProperty); }
            set { SetValue(ToolFrameWidthProperty, value); }
        }
        public NavigationService Navigator
        {
            get { return (NavigationService)GetValue(NavigatorProperty); }
            private set { SetValue(NavigatorProperty, value); }
        }
        public Frame ToolFrame
        {
            get { return (Frame)GetValue(ToolFrameProperty); }
            private set { SetValue(ToolFrameProperty, value); }
        }
        public Menu Menu
        {
            get { return (Menu)GetValue(MenuProperty); }
            private set { SetValue(MenuProperty, value); }
        }
        public Frame ContentFrame
        {
            get { return (Frame)GetValue(ContentFrameProperty); }
            private set { SetValue(ContentFrameProperty, value); }
        }

        public Switcher()
        {
            InitializeComponent();
            this.Navigator = this.MainPanel.NavigationService;
            this.ContentFrame = this.MainPanel;
            this.ToolFrame = this.ToolPanel;

            this.ToolFrameWidth = 70;
            this.Menu = this.SwitchMenu;
            this.ToolPanel.Width = 0;

        }
        private static void OnMainPageObjectChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is object)
            {
                var source = (Switcher)d;
                source.SetMain(e.NewValue);
            }
        }
        private void btnTools_Click(object sender, RoutedEventArgs e)
        {
            ShowTools();
        }

        public void ShowTools()
        {
            DoubleAnimation a = null;
            if (this.ToolPanel.Source == null) this.ToolPanel.Navigate(this.ToolPage);

            if (!_toolShow)
            {
                a = new DoubleAnimation(this.ToolFrameWidth, TimeSpan.FromSeconds(0.3));
                a.From = 0;
            }
            else
            {
                a = new DoubleAnimation(0, TimeSpan.FromSeconds(0.3));
                a.From = ToolFrameWidth;
            }

            ToolPanel.BeginAnimation(Frame.WidthProperty, a);
            _toolShow = !_toolShow;
        }
        private void SetMain(object o)
        {
            this.MainPanel.Navigate(o);
        }
    }
}
