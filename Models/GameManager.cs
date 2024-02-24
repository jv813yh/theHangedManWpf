using System.Windows;
using theHangedManWpf.Services;
using theHangedManWpf.Services.LoadingWordProviders;
using theHangedManWpf.Stores;

namespace theHangedManWpf.Models
{
    public class GameManager
    {
        private readonly ILoadingWord _loadingWord;

        public NavigationStore NavigationStore { get; set; }
        public Game CurrentGame { get; set; }
        public Dictionary<int, string> GuessingWordsDictionary { get; set; }

        public GameManager(ILoadingWord loadingWord, NavigationStore navigationStore) 
        {
            _loadingWord = loadingWord;

            NavigationStore = navigationStore;
        }

        public static GameManager CreatingGameManager(ILoadingWord loadingWord, NavigationStore navigationStore)
        {
            GameManager gameManagerReturn = new GameManager(loadingWord, navigationStore);

            gameManagerReturn.LoadingWords();
            gameManagerReturn.StartNewGame();

            return gameManagerReturn;
        }

        /// <summary>
        /// We create a new instance of Game when starting a new game
        /// </summary>
        public void StartNewGame()
        {
            try
            {
                CurrentGame = new Game(null, 
                    new GuessedWord(GuessingWordsDictionary.GetValueOrDefault(Random.Shared.Next(0, GuessingWordsDictionary.Count + 1), "default")));
            }
            catch (Exception)
            {

                MessageBox.Show("Oh no, something went wrong with word generation, please restart the game", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadingWords()
        {
            try
            {
                if (_loadingWord != null)
                {
                    GuessingWordsDictionary = _loadingWord.GetGuessingWord();
                } 
                else
                {
                    MessageBox.Show("Problem with loading the words, please start the game again", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
