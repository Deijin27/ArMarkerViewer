using ArMarkerViewer.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using ArMarkerViewer.Core;
using System.Linq;
using System.Windows;

namespace ArMarkerViewer
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel,
                    viewModel => viewModel.PokemonId,
                    view => view.PokemonIcon.Source,
                    Conversions.PokemonIdToIcon)
                    .DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.PokemonId,
                    view => view.PokemonName.Text,
                    Conversions.PokemonIdToName)
                    .DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.PokemonId,
                    view => view.ArMarkerImage.Source,
                    id => Conversions.BitmapToImageSource(ArMarker.PokemonIdToImage(id, 25)))
                    .DisposeWith(disposable);

                this.Bind(ViewModel,
                    viewModel => viewModel.PokemonId,
                    view => view.IdNumberBox.Value)
                    .DisposeWith(disposable);


                this.PokemonList.ItemsSource = ViewModel.PokemonIds.Select(id => new PokemonListItemViewModel(id));
                

                this.Bind(ViewModel,
                    vm => vm.ListSelectedItem,
                    v => v.PokemonList.SelectedItem)
                    .DisposeWith(disposable);

                this.BindCommand(ViewModel,
                    vm => vm.ListSelectionChanged,
                    v => v.PokemonList,
                    nameof(PokemonList.SelectionChanged))
                    .DisposeWith(disposable);


                #region ArMarker Toggle Buttons

                // X 8 5 2
                // X 9 X 7
                // X X 9 4
                // 0 3 6 1

                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit8, view => view.ArMarkerButton0).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit5, view => view.ArMarkerButton1).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit2, view => view.ArMarkerButton2).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit9, view => view.ArMarkerButton3).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit7, view => view.ArMarkerButton4).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit9, view => view.ArMarkerButton5).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit4, view => view.ArMarkerButton6).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit0, view => view.ArMarkerButton7).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit3, view => view.ArMarkerButton8).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit6, view => view.ArMarkerButton9).DisposeWith(disposable);
                this.BindCommand(ViewModel, viewModel => viewModel.ToggleBit1, view => view.ArMarkerButton10).DisposeWith(disposable);

                #endregion


            });
        }
    }
}
