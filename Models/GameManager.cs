using System.Windows;
using theHangedManWpf.Services.LoadingWordProviders;

namespace theHangedManWpf.Models
{
    public class GameManager
    {
        // Interface ILodingWord is used to load words from input stream
        private readonly ILoadingWords _loadingWord;

        // Dictionary with words for guessing
        private Dictionary<int, string> GuessingWordsDictionary { get; set; }

        // Current game instance
        public Game CurrentGame { get; set; }

        public bool IsGameStartedValid { get; private set; } = true;
        public string ConnectionString { get; }


        public GameManager(ILoadingWords loadingWord) 
        {
            _loadingWord = loadingWord;
            ConnectionString = _loadingWord.ConnectionString;
        }

        public static GameManager CreatingGameManager(ILoadingWords loadingWord)
        {
            GameManager gameManagerReturn = new GameManager(loadingWord);

            // Load words from input file
            gameManagerReturn.LoadingWords();
            // Get random word for the game
            gameManagerReturn.StartNewGame();

            return gameManagerReturn;
        }

        /// <summary>
        /// We create a new instance of Game when starting a new game
        /// </summary>
        public void StartNewGame()
        {
            if (GuessingWordsDictionary.Count == 1)
            {
                IsGameStartedValid = false;
            }

            CurrentGame = new Game(null, 
                new GuessedWord(GuessingWordsDictionary.GetValueOrDefault(Random.Shared.Next(0, GuessingWordsDictionary.Count + 1), "default")));
        }

        private void LoadingWords()
        {

            GuessingWordsDictionary = _loadingWord.GetGuessingWord();
        }
    }
}
