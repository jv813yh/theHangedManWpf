using System.Collections.ObjectModel;
using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.Services.PlayersWrittingProviders;

namespace theHangedManWpf.ViewModels
{
    public class HighScoresViewModel : ViewModelBase
    {
        private readonly string _connectionString = "highScoresPlayers.xml";

        private readonly GameManager _gameManager;

        private readonly ObservableCollection<PlayerViewModel> _players;
        public IEnumerable<PlayerViewModel> Players => _players;

        public ICommand LoadHighScoresPlayersCommand { get; }
        public ICommand WritePlayerCommand { get; }
        public ICommand NewGameCommand { get; }
        public ICommand QuitGameCommand { get; }

        public HighScoresViewModel(GameManager gameManager, NavigationService navigationService)
        {
            _gameManager = gameManager;

            _players = new ObservableCollection<PlayerViewModel>();

            LoadHighScoresPlayersCommand = new LoadHighScoresPlayersCommand(this, _connectionString);

            WritePlayerCommand = new WritePlayerToXmlCommand(this, new WrittingPlayersToXML(Players, _connectionString));

            NewGameCommand = new NewGameCommad(_gameManager, new NavigateCommand(navigationService));

            QuitGameCommand = new CloseGameCommand();
        }

        public static HighScoresViewModel ReturnHighScoresViewModel(GameManager gameManager, NavigationService navigationService)
        {
            HighScoresViewModel returnViewModel = new HighScoresViewModel(gameManager, navigationService);

            returnViewModel.LoadHighScoresPlayersCommand.Execute(null);

            returnViewModel.WritePlayerCommand.Execute(null);

            return returnViewModel;
        }

        public void UpdatePlayers(IEnumerable<PlayerViewModel> playersFromXml)
        {
            if (playersFromXml is not null)
            {
                _players.Clear();

                foreach (PlayerViewModel playerViewModel in playersFromXml)
                {
                    _players.Add(playerViewModel);
                }
            }
        }

        public void MapToPlayerViewModel()
        {
            _players.Add(new PlayerViewModel(_gameManager.CurrentGame));
        }
    }
}
