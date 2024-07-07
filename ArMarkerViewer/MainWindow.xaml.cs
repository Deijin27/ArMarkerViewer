using ArMarkerViewer.ViewModels;
using ArMarkerViewer.Core;
using System.Linq;
using System.Windows;

namespace ArMarkerViewer
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
