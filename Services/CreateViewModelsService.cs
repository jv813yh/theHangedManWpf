using theHangedManWpf.Models;
using theHangedManWpf.Stores;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Services
{
    public class CreateViewModelsService
    {
        private readonly GameManager _gameManager;

        private NavigationStore _navigationStore;

        public CreateViewModelsService(GameManager gameManager, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _gameManager = gameManager;
        }


        public GameMenuViewModel CreateGameMenuViewModel() 
            => new GameMenuViewModel(new NavigationService(_navigationStore, CreateLetsPlayViewModel), _gameManager);

        public LetsPlayViewModel CreateLetsPlayViewModel() 
            => new LetsPlayViewModel(new NavigationService(_navigationStore, CreatePlayingGameViewModel) , _gameManager);

        public PlayingGameViewModel CreatePlayingGameViewModel()
            => new PlayingGameViewModel(_gameManager, new NavigationService(_navigationStore, CreateHighScoresViewModel),
                new NavigationService(_navigationStore, CreateYouLostViewModel));

        public HighScoresViewModel CreateHighScoresViewModel()
            => new HighScoresViewModel(_gameManager);
        
        public YouLostViewModel CreateYouLostViewModel()
            => new YouLostViewModel(_gameManager);
    }
}
