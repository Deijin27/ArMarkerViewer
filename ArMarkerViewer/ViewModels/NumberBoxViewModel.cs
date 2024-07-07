
using System.Windows.Input;

namespace ArMarkerViewer.ViewModels
{
    public class NumberBoxViewModel : ViewModelBase
    {
        public NumberBoxViewModel()
        {
            Increment = new RelayCommand(() => { if (Value < Max) Value++; });
            Decrement = new RelayCommand(() => { if (Value > Min) Value--; });
        }

        public const ushort Min = 0;
        public const ushort Max = 0x3FF;

        ushort _value = 0;
        public ushort Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public ICommand Increment { get; }
        public ICommand Decrement { get; }
    }
}
