namespace theHangedManWpf.Models
{
    public class GuessedWord
    {
        // The word we guess in the game
        public string GuessWord { get; set; }

        // Number of characters mistakes by the player
        public int CountOfMistakes { get; set; } = 0;

        // Number of characters guessed by the player
        public int CountOfGuessCharacters { get; set; } = 0;

        // Number of characters guessed by the
        public int AttemptsLeft { get; set; } = 11;

        public GuessedWord(string guessWord)
        {
            GuessWord = guessWord;
        }

        // Constructor for XAML deserialization
        public GuessedWord()
        {
            
        }

        public override string ToString()
        {
            return $"{GuessWord}";
        }
    }
}
