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
        // The connection string to the xml file
        private readonly string _connectionString = "highScoresPlayers.xml";

        // The game manager
        private readonly GameManager _gameManager;

        // The list of players
        private readonly ObservableCollection<PlayerViewModel> _players;

        // The list of players order by level of dificulty and count of mistakes
        public IEnumerable<PlayerViewModel> Players => _players 
            .OrderByDescending(p => p.LevelOfDificulty).ThenBy(p => p.CountOfMistakes);

        // Commands 
        // to load the players from the xml file,
        // write the current player to the xml file,
        // start a new game and quit the game
        public ICommand LoadHighScoresPlayersCommand { get; }
        public ICommand WritePlayerCommand { get; }
        public ICommand NewGameCommand { get; }
        public ICommand QuitGameCommand { get; }

        public HighScoresViewModel(GameManager gameManager, NavigationService navigationService)
        {
            // Initialize the game manager 
            _gameManager = gameManager;

            // Initialize the list of players
            _players = new ObservableCollection<PlayerViewModel>();

            // Initialize the commands with the view model and the connection string and loading players from xml file
            LoadHighScoresPlayersCommand = new LoadHighScoresPlayersCommand(this, _connectionString);

            // Initialize the commands with the view model and the connection string and writing Players to the xml file
            WritePlayerCommand = new WritePlayersToXmlCommand(this, new WrittingPlayersToXML(Players, _connectionString));

            // Initialize the commands with the game manager and the navigation service with starting a new game
            NewGameCommand = new NewGameCommad(_gameManager, new NavigateCommand(navigationService));

            // Initialize the command with quitting the game
            QuitGameCommand = new CloseGameCommand();
        }

        // Return the HighScoresViewModel with the players from the xml file and the current player
        public static HighScoresViewModel ReturnHighScoresViewModel(GameManager gameManager, NavigationService navigationService)
        {
            HighScoresViewModel returnViewModel = new HighScoresViewModel(gameManager, navigationService);

            returnViewModel.LoadHighScoresPlayersCommand.Execute(null);

            returnViewModel.WritePlayerCommand.Execute(null);

            return returnViewModel;
        }

        // Update the players from the xml file
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

        // Map the players to the view model and add playerViewModel to the list
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
