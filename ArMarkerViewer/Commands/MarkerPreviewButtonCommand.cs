using System;
using System.Windows.Input;

namespace ArMarkerViewer.Commands
{
    public class MarkerPreviewButtonCommand : ICommand
    {
        public MarkerPreviewButtonCommand(int bitOffset, Action<ushort> executeToggle)
        {
            _toggle = (ushort)(1 << bitOffset);
            _execute = executeToggle;
        }

        public event EventHandler CanExecuteChanged;

        private readonly ushort _toggle;
        private readonly Action<ushort> _execute;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(_toggle);
        }
    }
}
