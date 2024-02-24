using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;

namespace theHangedManWpf.ViewModels
{
    public class YouLostViewModel : ViewModelBase
    {
        private readonly GameManager _gameManager;

        public string YourNotGuessedWord => _gameManager.CurrentGame.CurrentWord.GuessWord;

        public ICommand NewGameCommand { get; }
        public ICommand QuitGameCommand { get; }

        public YouLostViewModel(GameManager gameManager, NavigationService navigationService)
        {
            _gameManager = gameManager;

            NewGameCommand = new NewGameCommad(_gameManager, new NavigateCommand(navigationService));

            QuitGameCommand = new CloseGameCommand();
        }
    }   
}
