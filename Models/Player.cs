namespace theHangedManWpf.Models
{
    // Class representing a player in the game
    public class Player
    {
        // Name of the player
        public string NickName { get; } = "";

        // Constructor to initialize a player with name 
        public Player(string name)
        {
            NickName = name;
        }

        // Constructor for XAML deserialization
        public Player()
        {
            
        }

        // Override of the ToString method to provide string representation of the player
        public override string ToString()
        {
            return $"{NickName}";
        }
    }
}
