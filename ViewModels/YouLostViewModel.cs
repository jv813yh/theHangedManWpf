using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;

namespace theHangedManWpf.ViewModels
{
    public class YouLostViewModel : ViewModelBase
    {
        private readonly GameManager _gameManager;

        // This property is used to display the word that the player was trying to guess
        public string YourNotGuessedWord 
            => _gameManager.CurrentGame.CurrentWord.GuessWord;

        // Command to start a new game
        public ICommand NewGameCommand { get; }

        // Command to quit game
        public ICommand QuitGameCommand { get; }

        public YouLostViewModel(GameManager gameManager, NavigationService navigationService)
        {
            _gameManager = gameManager;

            NewGameCommand = new NewGameCommad(_gameManager, new NavigateCommand(navigationService));

            QuitGameCommand = new CloseGameCommand();
        }
    }   
}
