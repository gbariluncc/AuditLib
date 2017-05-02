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
using AuditControls.Controls.Commands;
using System.Windows.Media.Animation;
using Audits.Infastructure.Commands;

namespace AuditControls.Controls
{
    /// <summary>
    /// Interaction logic for SlidePage.xaml
    /// </summary>
    public partial class SlidePage : UserControl
    {
        private const double END_POS = 450.0;
        private bool _showRight;

        //Dependencies
        public static DependencyProperty NextActionProperty = DependencyProperty.Register("NextAction", typeof(IClickBehavior), typeof(SlidePage),
            new PropertyMetadata(OnNextActionChange));
        public static DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(DelegateCommand), typeof(SlidePage));
        public static DependencyProperty CloseActionProperty = DependencyProperty.Register("CloseAction", typeof(IClickBehavior), typeof(SlidePage));

        public static DependencyProperty SlideLeftActionProperty = DependencyProperty.Register("SlideLeftAction", typeof(IClickBehavior), typeof(SlidePage));
        public static DependencyProperty SlideRightActionProperty = DependencyProperty.Register(("SlideRightAction"), typeof(IClickBehavior), typeof(SlidePage));
        public static DependencyProperty PageLeftProperty = DependencyProperty.RegisterAttached("PageLeft", typeof(string), typeof(SlidePage),
            new UIPropertyMetadata(null, OnLeftPageChange));
        public static DependencyProperty CanMoveNextProperty = DependencyProperty.Register("CanMoveNext", typeof(bool), typeof(SlidePage),
            new PropertyMetadata(OnCanMoveNext));
        public static DependencyProperty PageRightPoperty = DependencyProperty.RegisterAttached("PageRight", typeof(string), typeof(SlidePage),
            new UIPropertyMetadata(null, OnRightPageChange));
        public static DependencyProperty ShowSliderProperty = DependencyProperty.RegisterAttached("ShowSlider", typeof(bool), typeof(SlidePage),
            new UIPropertyMetadata((bool)true, OnStateChange));
        public static DependencyProperty IsBusyProperty = DependencyProperty.RegisterAttached("IsBusy", typeof(bool), typeof(SlidePage),
            new UIPropertyMetadata((bool)false, OnIsBusyChange));
        public static DependencyProperty PageLeftObjectProperty = DependencyProperty.RegisterAttached("PageLeftObject", typeof(object), typeof(SlidePage),
            new UIPropertyMetadata((object)null, OnPageLeftObjectChange));
        public static DependencyProperty PageRightObjectProperty = DependencyProperty.RegisterAttached("PageRightObject", typeof(object), typeof(SlidePage),
            new UIPropertyMetadata((object)null, OnPageRightObjectChange));
        public static DependencyProperty ShowRightProperty = DependencyProperty.RegisterAttached("ShowRight", typeof(bool), typeof(SlidePage),
            new UIPropertyMetadata((object)false, OnIsShowRightChange));
        public static DependencyProperty ShowMainControlsProperty = DependencyProperty.RegisterAttached("ShowMainControls", typeof(bool), typeof(SlidePage),
            new UIPropertyMetadata((object)true, OnShowMainControlsChange));

        public SlidePage()
        {
            InitializeComponent();
            Slider.IsRotated = true;

            this.AnimateButton(1);
            this.SlideLeftAction = null;
            this.SlideRightAction = null;
            this.CanMoveNext = true;
            this.ShowRight = false;

            RootElement.DataContext = this;
            btnNext.DataContext = this;
        }
        public RotatingButton NextButton
        {
            get { return this.btnNext; }
        }
        public Frame FrameLeft
        {
            get { return this.frameLeft; }
        }
        public Frame FrameRight
        {
            get { return this.frameRight; }
        }

        public bool ShowSlider
        {
            get
            {
                return (bool)GetValue(ShowSliderProperty);
            }
            set
            {
                SetValue(ShowSliderProperty, value);
            }
        }
        public bool ShowMainControls
        {
            get
            {
                return (bool)GetValue(ShowMainControlsProperty);
            }
            set
            {
                SetValue(ShowMainControlsProperty, value);
            }
        }
        private static void OnRightPageChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string)
            {
                var source = (SlidePage)d;
                source.SetRight((string)e.NewValue);
            }
        }
        private static void OnShowMainControlsChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool)
            {
                var source = (SlidePage)d;
                source.MainControlsVisible((bool)e.NewValue);
            }
        }
        private static void OnPageLeftObjectChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is object)
            {
                var source = (SlidePage)d;
                source.SetLeft(e.NewValue);
            }
        }
        private static void OnPageRightObjectChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is object)
            {
                var source = (SlidePage)d;
                source.SetRight(e.NewValue);
            }
        }
        private static void OnIsBusyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool)
            {
                var source = (SlidePage)d;
                source.ShowBusy((bool)e.NewValue);
            }
        }
        private static void OnIsShowRightChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool)
            {
                var source = (SlidePage)d;
                source.ShowRightPanel((bool)e.NewValue);
            }
        }
        private static void OnLeftPageChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string)
            {
                var source = (SlidePage)d;
                source.SetLeft((string)e.NewValue);
            }
        }
        private static void OnNextActionChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is IClickBehavior)
            {
                var source = (SlidePage)d;
                source.btnNext.ForwardClickBehavior = (IClickBehavior)e.NewValue;
            }
        }
        private static void OnCanMoveNext(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool)
            {
                var source = (SlidePage)d;
                source.btnNext.IsEnabled = (bool)e.NewValue;
            }
        }
        private static void OnStateChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool)
            {
                var source = (SlidePage)d;
                source.SetState((bool)e.NewValue);
            }
        }

        public void SetLeft(object page)
        {
            this.frameLeft.Navigate(page);
        }
        public void SetRight(object page)
        {
            this.frameRight.Navigate(page);
        }
        public void SetLeft(string page)
        {
            Uri path = new Uri(page, UriKind.Relative);

            this.frameLeft.Source = path;
        }
        public void SetRight(string page)
        {
            Uri path = new Uri(page, UriKind.Relative);
            this.frameRight.Source = path;
        }

        public void ShowBusy(bool isBusy)
        {
            if (isBusy)
            {
                this.SpinnerContainer.Visibility = System.Windows.Visibility.Visible;
                this.Slider.IsEnabled = false;
            }
            else
            {
                this.SpinnerContainer.Visibility = System.Windows.Visibility.Collapsed;
                this.Slider.IsEnabled = true;
            }
        }
        public void ShowRightPanel(bool showRight)
        {
            AnimatePanel(showRight);
        }

        public void SetState(bool isDisables)
        {
            if (!isDisables)
            {
                canvSlider.Visibility = Visibility.Collapsed;
            }
            else
            {
                canvSlider.Visibility = System.Windows.Visibility.Visible;
            }
        }
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }
        public bool ShowRight
        {
            get { return (bool)GetValue(ShowRightProperty); }
            set { SetValue(ShowRightProperty, value); }
        }

        public string PageLeft
        {
            set
            {
                //this.frameLeft.Navigate(Type.GetType(value));
                SetValue(PageLeftProperty, value);
            }
            get
            {
                return (string)GetValue(PageLeftProperty);
            }
        }
        public string PageRight
        {
            set
            {
                //this.frameRight.Navigate(Type.GetType(value));
                SetValue(PageRightPoperty, value);
            }
            get
            {
                return (string)GetValue(PageRightPoperty);
            }
        }

        public DelegateCommand Command
        {
            get { return (DelegateCommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public bool CanMoveNext
        {
            get { return (bool)GetValue(CanMoveNextProperty); }
            set { SetValue(CanMoveNextProperty, value); }
        }

        public object PageLeftObject
        {
            get { return (object)GetValue(PageLeftObjectProperty); }
            set { SetValue(PageLeftObjectProperty, value); }
        }
        public object PageRightObject
        {
            get { return (object)GetValue(PageRightObjectProperty); }
            set { SetValue(PageRightObjectProperty, value); }
        }
        public IClickBehavior CloseAction
        {
            private get { return (IClickBehavior)GetValue(CloseActionProperty); }
            set { SetValue(CloseActionProperty, value); }
        }
        public IClickBehavior NextAction
        {
            private get { return (IClickBehavior)GetValue(NextActionProperty); }
            set { SetValue(NextActionProperty, value); this.btnNext.ForwardClickBehavior = value; }
        }
        public IClickBehavior SlideLeftAction
        {
            set
            {
                Action<object> slideTarget = delegate(object o) { this.ShowRight = !this.ShowRight; };
                this.Slider.ForwardClickBehavior = new SliderBehavior(value, new DelegateCommand(slideTarget));
                SetValue(SlideLeftActionProperty, new SliderBehavior(value, new DelegateCommand(slideTarget)));
            }
            private get
            {
                return (IClickBehavior)GetValue(SlideLeftActionProperty);
            }
        }
        public IClickBehavior SlideRightAction
        {
            set
            {
                Action<object> slideTarget = delegate(object o) { this.ShowRight = !this.ShowRight; };
                this.Slider.BackClickBehavior = new SliderBehavior(value, new DelegateCommand(slideTarget));
                SetValue(SlideRightActionProperty, new SliderBehavior(value, new DelegateCommand(slideTarget)));
            }
            private get
            {
                return (IClickBehavior)GetValue(SlideRightActionProperty);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.CloseAction != null) this.CloseAction.Click(sender, e);
        }
        private void AnimateButton(double to)
        {
            double left = 0.0;
            double final = 0.0;

            if (to > 0)
            {
                left = 0.0;
                final = END_POS;
                Slider.Rotate(true);
            }
            else
            {
                final = 0.0;
                left = END_POS;
                Slider.Rotate(false);
            }

            TranslateTransform trans = new TranslateTransform();
            Slider.RenderTransform = trans;

            DoubleAnimation b = new DoubleAnimation(left, final, TimeSpan.FromSeconds(0.2));
            trans.BeginAnimation(TranslateTransform.XProperty, b);
        }
        private void AnimatePanel(bool showRight)
        {
            DoubleAnimation a;

            if (!showRight)
            {
                a = new DoubleAnimation(470, TimeSpan.FromSeconds(0.3));
                a.From = 0;

                AnimateButton(1);

                //_showRight = true;
                //this.ShowRight = true;
            }
            else
            {
                a = new DoubleAnimation(0, TimeSpan.FromSeconds(0.3));
                a.From = 470;

                AnimateButton(0);
                //_showRight = false;
                //this.ShowRight = false;
            }

            _showRight = !_showRight;

            this.ShowMainControls = showRight;
            //MainControlsVisible(showRight);
            frameLeft.BeginAnimation(Frame.WidthProperty, a);
        }

        public void MainControlsVisible(bool hide)
        {
            if (hide)
            {
                this.MainControls.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                this.MainControls.Visibility = System.Windows.Visibility.Visible;
            }
        }


    }
}
