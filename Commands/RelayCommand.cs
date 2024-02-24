using System.Windows.Input;

namespace theHangedManWpf.Commands
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        // Constructor that takes an action to execute when the command is invoked.
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        // Constructor that takes an action to execute and a predicate to determine if the command can be executed.
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Event that is raised when the command's execution state changes.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Determines if the command can be executed.
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        // Executes the command.
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
