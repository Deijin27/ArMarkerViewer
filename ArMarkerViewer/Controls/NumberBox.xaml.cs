using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
