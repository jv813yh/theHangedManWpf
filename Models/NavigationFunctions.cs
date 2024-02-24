using theHangedManWpf.Services;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Models
{
    public class NavigationFunctions
    {
        private readonly GameManager _gameManager;

        public NavigationFunctions(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public GameMenuViewModel CreateGameMenuViewModel()
        => new GameMenuViewModel(new NavigationService(_gameManager.NavigationStore, CreateLetsPlayViewModel), _gameManager);

        public LetsPlayViewModel CreateLetsPlayViewModel()
            => new LetsPlayViewModel(new NavigationService(_gameManager.NavigationStore, CreatePlayingGameViewModel), _gameManager);

        public PlayingGameViewModel CreatePlayingGameViewModel()
            => new PlayingGameViewModel(_gameManager, new NavigationService(_gameManager.NavigationStore, CreateHighScoresViewModel),
                new NavigationService(_gameManager.NavigationStore, CreateYouLostViewModel));

        public HighScoresViewModel CreateHighScoresViewModel()
            => new HighScoresViewModel(_gameManager);
        public YouLostViewModel CreateYouLostViewModel()
            => new YouLostViewModel(_gameManager);
    }
}
