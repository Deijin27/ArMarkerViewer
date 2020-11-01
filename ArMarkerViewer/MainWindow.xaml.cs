using ArMarkerViewer.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
        }

        private void PokemonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as MainWindowViewModel).PokemonList_SelectionChanged(sender as ListView);
        }
    }
}
