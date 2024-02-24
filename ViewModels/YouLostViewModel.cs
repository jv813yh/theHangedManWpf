using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;

namespace theHangedManWpf.ViewModels
{
    public class YouLostViewModel: ViewModelBase
    {
        private readonly GameManager _gameManager;

        public string YourNotGuessedWord => _gameManager.CurrentGame.CurrentWord.GuessWord;

        public ICommand NewGameAsNewPlayerCommand { get; }
        public ICommand NewGameAsTheSamePlayerCommand { get; }
        public ICommand QuitGameCommand { get; }

        public YouLostViewModel(GameManager gameManager)
        {
            _gameManager = gameManager;

           // NewGameAsNewPlayerCommand = new NewGameAsNewPlayerCommand(_gameManager, _gameManager.GetnavigationStore);

            QuitGameCommand = new CloseGameCommand();
        }

        /*
        private LetsPlayViewModel CreateLetsPlayViewModel()
            => new LetsPlayViewModel(new NavigationService(_gameManager.NavigationStore, CreatePlayingGameViewModel), _gameManager);
        */
    
        }
}
