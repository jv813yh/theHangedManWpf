namespace theHangedManWpf.Models
{
    // Enum representing the game state of the game
    public enum GameState
    {
        InProgress, Win, Lose
    }
    // Class representing a player in the game
    public class Game
    {
        // Specific player for a specific game
        public Player? Player { get; set; }

        // Specific word  for a specific game
        public GuessedWord? CurrentWord { get; set; }

        // Difficulty level chosen by the player
        public string PlayerDifficulty { get; set; }

        // Current state of the game
        public GameState PlayerGameState { get; set; }

        public Game(Player player, GuessedWord currentWord)
        {
            Player = player;
            CurrentWord = currentWord;
        }

        // for XML deserialization
        public Game()
        {
            
        }

    }
}
