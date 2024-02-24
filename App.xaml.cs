using System.Windows;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.Services.GameEvaluationProviders;
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

        private readonly GameManager _gameManager;

        public App()
        {
            _gameManager = GameManager.CreatingGameManager(new LoadingWord(_connectionString), new NavigationStore());
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            _gameManager.NavigationStore.CurrentViewModel = CreateGameMenuViewModel();


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_gameManager.NavigationStore)
            };

            MainWindow.Show();


            base.OnStartup(e);
        }



        /// ///////MOZNO PRESUNUT DO GAMEMANAGERA ???? ////////////////////////////////// 
        /// ///////MOZNO PRESUNUT DO GAMEMANAGERA ???? //////////////////////////////////


        private GameMenuViewModel CreateGameMenuViewModel() 
            => new GameMenuViewModel(new NavigationService(_gameManager.NavigationStore, CreateLetsPlayViewModel), _gameManager);

        private LetsPlayViewModel CreateLetsPlayViewModel() 
            => new LetsPlayViewModel(new NavigationService(_gameManager.NavigationStore, CreatePlayingGameViewModel) , _gameManager);

        private PlayingGameViewModel CreatePlayingGameViewModel()
            => new PlayingGameViewModel(_gameManager, new NavigationService(_gameManager.NavigationStore, CreateHighScoresViewModel),
                new NavigationService(_gameManager.NavigationStore, CreateYouLostViewModel));

        private HighScoresViewModel CreateHighScoresViewModel()
            => new HighScoresViewModel(_gameManager);
        private YouLostViewModel CreateYouLostViewModel()
            => new YouLostViewModel(_gameManager);
    }
}
