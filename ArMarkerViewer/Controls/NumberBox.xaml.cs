using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArMarkerViewer.ViewModels;
using ReactiveUI;

namespace ArMarkerViewer.Controls
{
    /// <summary>
    /// Interaction logic for NumberBox.xaml
    /// </summary>
    public partial class NumberBox : UserControl, IViewFor<NumberBoxViewModel>
    {
        public NumberBox()
        {
            InitializeComponent();
            ViewModel = new NumberBoxViewModel();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel,
                    vm => vm.Value,
                    v => v.NumberTextBox.Text,
                    num => num.ToString(),
                    str => ushort.TryParse(str, out ushort i) ? i : NumberBoxViewModel.Min)
                    .DisposeWith(disposable);

                this.Bind(ViewModel,
                    vm => vm.Value,
                    v => v.Value)
                    .DisposeWith(disposable);

                this.BindCommand(ViewModel,
                    vm => vm.Increment,
                    v => v.IncrementButton,
                    nameof(IncrementButton.Click))
                    .DisposeWith(disposable);

                this.BindCommand(ViewModel,
                    vm => vm.Decrement,
                    v => v.DecrementButton,
                    nameof(DecrementButton.Click))
                    .DisposeWith(disposable);

                NumberTextBox.PreviewTextInput += TextBox_PreviewTextInput;

            });
        }

        #region Value
        public static DependencyProperty ValueProperty = DependencyProperty.Register
        (
            nameof(Value),
            typeof(ushort),
            typeof(NumberBox),
            new FrameworkPropertyMetadata((ushort)0) // this default value is dodgy, it didn't work when i tried to make min max properties
        );

        public ushort Value
        {
            get => (ushort)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        #endregion

        #region IViewFor Implementation
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(
                nameof(ViewModel),
                typeof(NumberBoxViewModel),
                typeof(ReactiveUserControl<NumberBoxViewModel>),
                new PropertyMetadata(null));
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (NumberBoxViewModel?)value;
        }

        public NumberBoxViewModel ViewModel
        {
            get => (NumberBoxViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        #endregion

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // If it's invlaid, mark as handled so it doesn't proceed, else mark as not handled.
            string newText = ((TextBox)sender).Text + e.Text;
            e.Handled = !(ushort.TryParse(newText, out ushort i) && i >= NumberBoxViewModel.Min && i <= NumberBoxViewModel.Max);
        }
    
    }
}

/*

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ReactiveUI;

namespace ArMarkerViewer.Controls
{
    /// <summary>
    /// Interaction logic for NumberBox.xaml
    /// </summary>
    public partial class NumberBox : UserControl
    {
        public NumberBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static DependencyProperty ValueProperty = DependencyProperty.Register
        (
            nameof(Value), 
            typeof(ushort), 
            typeof(NumberBox), 
            new FrameworkPropertyMetadata(default(ushort), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

        public ushort Value
        {
            get => (ushort)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        private const ushort Min = 0;
        private const ushort Max = 0x3FF;


        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > Min)
            {
                Value--;
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < Max)
            {
                Value++;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // If it's invlaid, mark as handled so it doesn't proceed, else mark as not handled.
            string newText = ((TextBox)sender).Text + e.Text;
            e.Handled = !(ushort.TryParse(newText, out ushort i) && i >= Min && i <= Max);
        }

    }
}
/*
 using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ArMarkerViewer.Controls
{
    /// <summary>
    /// Interaction logic for NumberBox.xaml
    /// </summary>
    public partial class NumberBox : ReactiveUserControl<NumberBoxViewModel>
    {
        public NumberBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static DependencyProperty ValueProperty = DependencyProperty.Register
        (
            nameof(Value), 
            typeof(ushort), 
            typeof(NumberBox), 
            new FrameworkPropertyMetadata(default(ushort), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

        public ushort Value
        {
            get => (ushort)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        private const ushort Min = 0;
        private const ushort Max = 0x3FF;


        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > Min)
            {
                Value--;
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < Max)
            {
                Value++;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // If it's invlaid, mark as handled so it doesn't proceed, else mark as not handled.
            string newText = ((TextBox)sender).Text + e.Text;
            e.Handled = !(ushort.TryParse(newText, out ushort i) && i >= Min && i <= Max);
        }

    }
}
 
 */




/*
 using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ArMarkerViewer.Controls
{
    /// <summary>
    /// Interaction logic for NumberBox.xaml
    /// </summary>
    public partial class NumberBox : ReactiveUserControl<NumberBoxViewModel>
    {
        public NumberBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static DependencyProperty ValueProperty = DependencyProperty.Register
        (
            nameof(Value), 
            typeof(ushort), 
            typeof(NumberBox), 
            new FrameworkPropertyMetadata(default(ushort), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

        public ushort Value
        {
            get => (ushort)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        private const ushort Min = 0;
        private const ushort Max = 0x3FF;


        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > Min)
            {
                Value--;
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < Max)
            {
                Value++;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // If it's invlaid, mark as handled so it doesn't proceed, else mark as not handled.
            string newText = ((TextBox)sender).Text + e.Text;
            e.Handled = !(ushort.TryParse(newText, out ushort i) && i >= Min && i <= Max);
        }

    }
}
 
 */
