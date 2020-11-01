using ArMarkerViewer.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace ArMarkerViewer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            ToggleBit0 = new MarkerPreviewButtonCommand(0, ToggleBit);
            ToggleBit1 = new MarkerPreviewButtonCommand(1, ToggleBit);
            ToggleBit2 = new MarkerPreviewButtonCommand(2, ToggleBit);
            ToggleBit3 = new MarkerPreviewButtonCommand(3, ToggleBit);
            ToggleBit4 = new MarkerPreviewButtonCommand(4, ToggleBit);
            ToggleBit5 = new MarkerPreviewButtonCommand(5, ToggleBit);
            ToggleBit6 = new MarkerPreviewButtonCommand(6, ToggleBit);
            ToggleBit7 = new MarkerPreviewButtonCommand(7, ToggleBit);
            ToggleBit8 = new MarkerPreviewButtonCommand(8, ToggleBit);
            ToggleBit9 = new MarkerPreviewButtonCommand(9, ToggleBit);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private ushort pokemonIdValue = 0;
        public ushort PokemonId
        {
            get => pokemonIdValue;
            set
            {
                pokemonIdValue = value;
                NotifyChanged(nameof(PokemonId));
            }
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

        public void PokemonList_SelectionChanged(ListView list)
        {
            if (list.SelectedItem != null)
            {
                PokemonId = (ushort)list.SelectedItem;
                list.SelectedItem = null;
            }
        }

        void ToggleBit(ushort toggle) => PokemonId ^= toggle;

        public ICommand ToggleBit0 { get; set; }
        public ICommand ToggleBit1 { get; set; }
        public ICommand ToggleBit2 { get; set; }
        public ICommand ToggleBit3 { get; set; }
        public ICommand ToggleBit4 { get; set; }
        public ICommand ToggleBit5 { get; set; }
        public ICommand ToggleBit6 { get; set; }
        public ICommand ToggleBit7 { get; set; }
        public ICommand ToggleBit8 { get; set; }
        public ICommand ToggleBit9 { get; set; }
    }
}
