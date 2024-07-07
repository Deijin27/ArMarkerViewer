using ArMarkerViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace ArMarkerViewer.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ToggleBitCommand = new RelayCommand<string>(x => ToggleBit(int.Parse(x)));

            ListSelectionChangedCommand = new RelayCommand(() =>
            { 
                if (ListSelectedItem != null)
                {
                    PokemonId = ListSelectedItem.PokemonId;
                    ListSelectedItem = null;
                }
            });

            Items = PokemonIds.Select(x => new PokemonListItemViewModel(x)).ToList();
            ListSelectedItem = Items[0];
        }

        private ushort pokemonIdValue = 0;
        public ushort PokemonId
        {
            get => pokemonIdValue;
            set
            {
                if (SetProperty(ref pokemonIdValue, value))
                {
                    RaisePropertyChanged(nameof(PokemonName));
                    RaisePropertyChanged(nameof(PokemonIcon));
                    RaisePropertyChanged(nameof(ArImage));
                }
            }
        }

        public ImageSource ArImage => Conversions.BitmapToImageSource(ArMarker.PokemonIdToImage(PokemonId, 25));
        public string PokemonName => Conversions.PokemonIdToName(PokemonId);
        public ImageSource PokemonIcon => Conversions.PokemonIdToIcon(PokemonId);


        private PokemonListItemViewModel listItemValue = null;
        public PokemonListItemViewModel ListSelectedItem
        {
            get => listItemValue;
            set
            {
                if (SetProperty(ref listItemValue, value))
                {
                    PokemonId = value.PokemonId;
                }
            }
        }

        public List<PokemonListItemViewModel> Items { get; } 

        private static IEnumerable<ushort> PokemonIds
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

        public ICommand ListSelectionChangedCommand { get; }

        private void ToggleBit(int offset) => PokemonId ^= (ushort)(1 << offset);
        public ICommand ToggleBitCommand { get; }
    }
}
