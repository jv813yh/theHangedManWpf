using System.Windows.Threading;
using theHangedManWpf.Models;

namespace theHangedManWpf.Commands
{
    public class NewGameCommad : CommandBase
    {
        private readonly GameManager _gameManager;
        private readonly NavigateCommand _navigateCommand;
        private readonly DispatcherTimer? _dispatcherTimer;

        public NewGameCommad(GameManager gameManager, NavigateCommand navigateCommand, DispatcherTimer? dispatcherTimer = null)
        {
            _gameManager = gameManager;

            _navigateCommand = navigateCommand;
            _dispatcherTimer = dispatcherTimer;
        }

        public override void Execute(object? parameter)
        {
            // Reset time if the game is hard
            if(_gameManager.CurrentGame.PlayerDifficulty == "Hard" &&
                _dispatcherTimer != null)
            {
                _dispatcherTimer.Stop();
            }

            // Generate new word
            _gameManager.StartNewGame();

            // Navigate to the ViewModel according the command
            _navigateCommand.Execute(null);
        }
    }
}
