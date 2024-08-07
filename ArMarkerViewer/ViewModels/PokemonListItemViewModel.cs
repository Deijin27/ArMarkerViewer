﻿using ArMarkerViewer.Core;
using System.Windows.Media;

namespace ArMarkerViewer.ViewModels;

public class PokemonListItemViewModel : ViewModelBase
{
    public PokemonListItemViewModel(ushort id)
    {
        PokemonId = id;
        Icon = Conversions.PokemonIdToIcon(PokemonId);
        Name = Conversions.PokemonIdToName(PokemonId);
    }

    public ushort PokemonId { get; }
    public ImageSource Icon { get; }
    public string Name { get; }
}
