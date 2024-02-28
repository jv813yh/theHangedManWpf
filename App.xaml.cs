using System.Windows;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.Services.LoadingWordProviders;
using theHangedManWpf.Stores;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly string _connectionString = "inputWords.txt";

        private readonly NavigationStore _navigationStore;
        private readonly GameManager _gameManager;
       

        public App()
        {
            _navigationStore = new NavigationStore();
            _gameManager = GameManager.CreatingGameManager(new LoadingWord(_connectionString));
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            _navigationStore.CurrentViewModel = CreateGameMenuViewModel();


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();


            base.OnStartup(e);
        }


        /*
         * Maybe a better solution is to include it in a special class, 
         * for now in this version I keep it in the App class
         */

        // Create GameMenuViewModel for 
        public GameMenuViewModel CreateGameMenuViewModel()
         => new GameMenuViewModel(new NavigationService(_navigationStore, CreateLetsPlayViewModel), _gameManager);

        // Create LetsPlayViewModel for 
        public LetsPlayViewModel CreateLetsPlayViewModel()
            => new LetsPlayViewModel(new NavigationService(_navigationStore, CreatePlayingGameViewModel), _gameManager);

        // Create PlayingGameViewModel for
        public PlayingGameViewModel CreatePlayingGameViewModel()
            => PlayingGameViewModel.ReturnPlayingGameViewModel(_gameManager, new NavigationService(_navigationStore, CreateHighScoresViewModel),
                               new NavigationService(_navigationStore, CreateYouLostViewModel), new NavigationService(_navigationStore, CreateGameMenuViewModel));

        // Create HighScoresViewModel for
        public HighScoresViewModel CreateHighScoresViewModel()
            => HighScoresViewModel.ReturnHighScoresViewModel(_gameManager, new NavigationService(_navigationStore, CreateGameMenuViewModel));

        // Create YouLostViewModel for
        public YouLostViewModel CreateYouLostViewModel()
            => new YouLostViewModel(_gameManager, new NavigationService(_navigationStore, CreateGameMenuViewModel));

    }
}
