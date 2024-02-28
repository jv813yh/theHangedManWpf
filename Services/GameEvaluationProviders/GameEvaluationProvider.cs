using theHangedManWpf.Models;

namespace theHangedManWpf.Services.GameEvaluationProviders
{
    public class GameEvaluationProvider : IGameEvaluationProvider
    {
        
        private readonly NavigationService _winService;
        private readonly NavigationService _lostService;
        private readonly GuessedWord _guessedWord;

        // The difficulty of the game
        private string _difficulty;

        // Array to hold the letters that are guessed in bool values
        private readonly bool[] _holderBool;

        // The word that is binding to display to view
        private string _getEditedGuessedWord = "";

        // Property to get the number of attempts left
        public int AttemptsLeft { get; set; } = 11;

        // Property to get the edited guessed word
        public string GetEditedGuessedWord
        {
            get => _getEditedGuessedWord;

            set
            {
                _getEditedGuessedWord = value;
            }
        }

        public GameEvaluationProvider(GameManager gameManager, NavigationService winService,
            NavigationService lostService)
        {
            _guessedWord = gameManager.CurrentGame.CurrentWord;

            _winService = winService;
            _lostService = lostService;

            _holderBool = new bool[_guessedWord.GuessWord.Length];

            _difficulty = gameManager.CurrentGame.PlayerDifficulty;
        }

        // Method to evaluate the guessed word and navigate to win or lost view
        public void DoEvaluationGuessedWord(char guessedChar)
        {
            // If the guessed letter is in the word
            if(_guessedWord.GuessWord.Contains(guessedChar))
            {
                // Index of the guessed character in the word
                for (int i = 0; i < _guessedWord.GuessWord.Length; i++)
                {
                    // If the letter is in the word
                    if (_guessedWord.GuessWord[i] == guessedChar && _difficulty.Contains("Easy"))
                    {
                        // If all letters are guessed
                        ChangeHolderBoolAndVeriyLetters(i);
                    }
                    else if(_guessedWord.GuessWord[i] == guessedChar && !_holderBool[i])
                    {
                        // If only one letter is gussed
                        ChangeHolderBoolAndVeriyLetters(i);

                        break;
                    }
                }
            }
            else
            {
                // If the letter is not in the word

                AttemptsLeft =  --_guessedWord.AttemptsLeft;
                _guessedWord.CountOfMistakes++;

                if (AttemptsLeft == 0)
                {
                   _lostService.Navigate();
                }
            }

            // Edit the _getEditedGuessedWord word, that is binding to display to view
            EditedGuessedWord();
        }

        // Method to change the _holderBool and verify the all letters
        private void ChangeHolderBoolAndVeriyLetters(int i)
        {
            _holderBool[i] = true;

            // if all letters are guessed
            if (_holderBool.All(x => x == true))
            {
                _winService.Navigate();
            }
        }

        // Method to edit the _getEditedGuessedWord word
        // that is binding to display to view
        public void EditedGuessedWord()
        {
            // we can work with StringBuilder,
            // but we we always have one word for one game,
            // which does not contain that many letters 

            _getEditedGuessedWord = string.Empty;

            for (int i = 0; i < _holderBool.Length; i++)
            {
                if (_holderBool[i])
                {
                    _getEditedGuessedWord += _guessedWord.GuessWord[i];
                }
                else
                {
                    _getEditedGuessedWord += "_";
                }
                _getEditedGuessedWord += " ";
            }
        }
    }
}
