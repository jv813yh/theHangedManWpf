using System.Collections.ObjectModel;
using System.Windows;
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

            WritePlayerCommand = new WritePlayersToXmlCommand(this, new WrittingPlayersToXML(Players, _connectionString));

            NewGameCommand = new NewGameCommad(_gameManager, new NavigateCommand(navigationService));

            QuitGameCommand = new CloseGameCommand();
        }

        public static HighScoresViewModel ReturnHighScoresViewModel(GameManager gameManager, NavigationService navigationService)
        {
            HighScoresViewModel returnViewModel = new HighScoresViewModel(gameManager, navigationService);

            returnViewModel.LoadHighScoresPlayersCommand.Execute(null);

            if (returnViewModel.Players is null)
                MessageBox.Show("Players are null", "!!", MessageBoxButton.OK);

            returnViewModel.WritePlayerCommand.Execute(null);

            return returnViewModel;
        }

        public void UpdatePlayers(List<PlayerViewModel> playersFromXml)
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
            PlayerViewModel currentPlayer = new PlayerViewModel(_gameManager.CurrentGame);

            if(currentPlayer.Name.Length > 2)
            {
                _players.Add(currentPlayer);
            }
        }
    }
}
