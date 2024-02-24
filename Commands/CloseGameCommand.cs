using System.Windows;

namespace theHangedManWpf.Commands
{
    // This class represents a command that is executed when the user wants to close the game.
    public class CloseGameCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Thank you for your playing", "Close game", MessageBoxButton.OK);
            Environment.Exit(0);
        }
    }
}
