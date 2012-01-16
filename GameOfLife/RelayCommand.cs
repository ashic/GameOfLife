using System;
using System.Windows.Input;

namespace GameOfLife
{
    public class RelayCommand : ICommand
    {
        readonly Predicate<object> _canExecute;
        readonly Action<object> _executeAction;

        public RelayCommand(Action<object> executeAction, Predicate<object> canExecute = null)
        {
            _executeAction = executeAction;
            _canExecute = canExecute;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public void Execute(object parameter)
        {
            if (_executeAction != null)
                _executeAction(parameter);
        }

        #endregion

        public void UpdateCanExecute()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}