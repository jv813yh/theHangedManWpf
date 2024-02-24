using System;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.Services.LoadingWordProviders;

namespace theHangedManWpf.Stores
{
    public class GameStore
    {
        public GameManager GameManager { get; }
        public CreateViewModelsService GameService { get; }
        public NavigationStore NavigationStore { get; }

        public GameStore(string connectionString)
        {
            GameManager = new GameManager(new LoadingWord(connectionString));

            NavigationStore = new NavigationStore();

            GameService = new CreateViewModelsService(GameManager, NavigationStore);
        }

        // Function to start a new game
        public void StartNewGame()
        {
            GameManager.StartNewGame();
        }
    }
}
