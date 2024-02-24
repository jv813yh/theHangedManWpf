using System.Windows.Input;

namespace theHangedManWpf.Commands
{
    // This class represents a base class for commands in the application.
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
