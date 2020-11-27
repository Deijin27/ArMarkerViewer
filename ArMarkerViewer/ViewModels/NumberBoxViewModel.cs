using ReactiveUI;
using System.Reactive;

namespace ArMarkerViewer.ViewModels
{
    public class NumberBoxViewModel : ReactiveObject
    {
        public NumberBoxViewModel()
        {
            Increment = ReactiveCommand.Create(() => { if (Value < Max) Value++; });
            Decrement = ReactiveCommand.Create(() => { if (Value > Min) Value--; });
        }

        public const ushort Min = 0;
        public const ushort Max = 0x3FF;

        ushort _value = 0;
        public ushort Value
        {
            get => _value;
            set => this.RaiseAndSetIfChanged(ref _value, value);
        }

        public ReactiveCommand<Unit, Unit> Increment { get; }
        public ReactiveCommand<Unit, Unit> Decrement { get; }
    }
}
