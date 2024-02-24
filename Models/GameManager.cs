using System.Windows;
using theHangedManWpf.Services;
using theHangedManWpf.Services.LoadingWordProviders;
using theHangedManWpf.Stores;

namespace theHangedManWpf.Models
{
    public class GameManager
    {
        public Game CurrentGame { get; set; }

        private readonly ILoadingWord _loadingWord;
        public Dictionary<int, string> GuessingWordsDictionary { get; set; }

        public GameManager(ILoadingWord loadingWord) 
        {
            _loadingWord = loadingWord;
        }

        public static GameManager CreatingGameManager(ILoadingWord loadingWord)
        {
            GameManager gameManagerReturn = new GameManager(loadingWord);

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
