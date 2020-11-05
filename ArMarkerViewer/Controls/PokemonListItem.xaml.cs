using ArMarkerViewer.ValueConverters;
using ArMarkerViewer.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace ArMarkerViewer.Controls
{
    /// <summary>
    /// Interaction logic for PokemonListItem.xaml
    /// </summary>
    public partial class PokemonListItem : ReactiveUserControl<PokemonListItemViewModel>
    {
        public PokemonListItem()
        {
            InitializeComponent();
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
            });
        }
    }
}
