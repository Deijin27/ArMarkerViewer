using ReactiveUI;

namespace ArMarkerViewer.ViewModels
{
    public interface IPokemonListItemViewModel
    {
        ushort PokemonId { get; }
    }

    public class PokemonListItemViewModel : ReactiveObject, IPokemonListItemViewModel
    {
        public PokemonListItemViewModel(ushort id) => PokemonId = id;

        public ushort PokemonId { get; }
    }
}
