using System.Collections.Generic;
using ReactiveUI;
using System.Reactive;

namespace ArMarkerViewer.ViewModels
{
    public class MainWindowViewModel : ReactiveObject //, IPokemonListItemViewModel
    {
        public MainWindowViewModel()
        {
            ToggleBit0 = ReactiveCommand.Create(() => ToggleBit(0));
            ToggleBit1 = ReactiveCommand.Create(() => ToggleBit(1));
            ToggleBit2 = ReactiveCommand.Create(() => ToggleBit(2));
            ToggleBit3 = ReactiveCommand.Create(() => ToggleBit(3));
            ToggleBit4 = ReactiveCommand.Create(() => ToggleBit(4));
            ToggleBit5 = ReactiveCommand.Create(() => ToggleBit(5));
            ToggleBit6 = ReactiveCommand.Create(() => ToggleBit(6));
            ToggleBit7 = ReactiveCommand.Create(() => ToggleBit(7));
            ToggleBit8 = ReactiveCommand.Create(() => ToggleBit(8));
            ToggleBit9 = ReactiveCommand.Create(() => ToggleBit(9));

            ListSelectionChanged = ReactiveCommand.Create(() =>
            { 
                if (ListSelectedItem != null)
                {
                    PokemonId = ListSelectedItem.PokemonId;
                    ListSelectedItem = null;
                }
            });
        }

        private ushort pokemonIdValue = 0;
        public ushort PokemonId
        {
            get => pokemonIdValue;
            set => this.RaiseAndSetIfChanged(ref pokemonIdValue, value);
        }

        private PokemonListItemViewModel listItemValue = null;
        public PokemonListItemViewModel ListSelectedItem
        {
            get => listItemValue;
            set => this.RaiseAndSetIfChanged(ref listItemValue, value);
        }

        public IEnumerable<ushort> PokemonIds
        {
            get
            {
                for (ushort i = 0; i < 721; i++)
                {
                    yield return i;
                }
                for (ushort i = 725; i < 734; i++)
                {
                    yield return i;
                }
                for (ushort i = 988; i < 1012; i++)
                {
                    yield return i;
                }
            }
        }

        public ReactiveCommand<Unit, Unit> ListSelectionChanged { get; }

        private void ToggleBit(int offset) => PokemonId ^= (ushort)(1 << offset);
        public ReactiveCommand<Unit, Unit> ToggleBit0 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit1 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit2 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit3 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit4 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit5 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit6 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit7 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit8 { get; }
        public ReactiveCommand<Unit, Unit> ToggleBit9 { get; }
    }
}
