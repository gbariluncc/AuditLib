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
using Audits.Infastructure.Commands;

namespace AuditControls.Controls
{
    /// <summary>
    /// Interaction logic for RotatingButton.xaml
    /// </summary>
    public partial class RotatingButton : UserControl
    {
        public RotatingButton()
        {
            InitializeComponent();
            IsRotated = false;
            this.CanRotate = true;
            rootElement.DataContext = this;
        }

        public static DependencyProperty IsRotatedProperty = DependencyProperty.Register("IsRotated", typeof(bool), typeof(RotatingButton));
        public static DependencyProperty ForwardClickBehaviorProperty = DependencyProperty.Register("ForwardClickBehavior", typeof(IClickBehavior), typeof(RotatingButton),
            new PropertyMetadata(null));

        public static DependencyProperty BackClickBehaviorProperty = DependencyProperty.Register("BackClickBehavior", typeof(IClickBehavior), typeof(RotatingButton));
        public static DependencyProperty CanRotateProperty = DependencyProperty.Register("CanRotate", typeof(bool), typeof(RotatingButton));

        public static DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(DelegateCommand), typeof(RotatingButton));

        public DelegateCommand Command
        {
            get { return (DelegateCommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public bool CanRotate
        {
            get
            {
                return (bool)GetValue(CanRotateProperty);
            }
            set
            {
                SetValue(CanRotateProperty, value);
            }
        }
        public bool IsRotated
        {
            get { return (bool)GetValue(IsRotatedProperty); }
            set
            {
                SetValue(IsRotatedProperty, value);
                this.Rotate(value);
            }
        }
        public IClickBehavior ForwardClickBehavior
        {
            get { return (IClickBehavior)GetValue(ForwardClickBehaviorProperty); }
            set
            {
                SetValue(ForwardClickBehaviorProperty, value);
            }
        }
        public IClickBehavior BackClickBehavior
        {
            get { return (IClickBehavior)GetValue(BackClickBehaviorProperty); }
            set { SetValue(BackClickBehaviorProperty, value); }
        }

        void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CanRotate)
            {
                IsRotated = !IsRotated;
                if (IsRotated)
                {
                    this.Rotate(false);
                    if (ForwardClickBehavior != null)
                    {
                        ForwardClickBehavior.Click(sender, e);
                    }
                }
                else
                {
                    this.Rotate(true);
                    if (BackClickBehavior != null)
                    {
                        BackClickBehavior.Click(sender, e);
                    }
                }
            }
            else
            {
                if (ForwardClickBehavior != null) ForwardClickBehavior.Click(sender, e);
            }
        }

        public void Rotate(int degrees)
        {
            int to, from;

            from = 0;
            to = degrees;

            Rotate(from, to);
        }
        public void Rotate(bool forward)
        {
            int from, to;

            to = forward == true ? 180 : 0;
            from = forward == true ? 0 : 180;

            Rotate(from, to);
        }

        public void Rotate(int from, int to)
        {
            var rotateAnimation = new DoubleAnimation(from, to, TimeSpan.FromMilliseconds(300));
            var rt = (RotateTransform)btnNext.RenderTransform;
            rt.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
    }
}
