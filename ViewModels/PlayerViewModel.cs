using theHangedManWpf.Models;

namespace theHangedManWpf.ViewModels
{
    [Serializable()] 
    public class PlayerViewModel : ViewModelBase
    {
        private readonly Game _game;

        private string _name;
        public string Name 
        { 
            get => _game.Player.NickName;
            set
            {
                _name = value;
            }
        }
        private string _guessedWord;

        public string GuessedWord
        { 
            get => _game.CurrentWord.GuessWord;
            set
            {
                _guessedWord = value;
            }
        }
        private int _countOfMistakes;

        public int CountOfMistakes
        {
            get => _game.CurrentWord.CountOfMistakes;
            set
            {
                _countOfMistakes = value;
            }
        }

        private string _playerDifficulty;
        public string PlayerDifficulty
        {
            get => _game.PlayerDifficulty;
            set 
            {
                _playerDifficulty = value;      
            }
        }
       
        public PlayerViewModel(Game game)
        {
            _game = game;
        }

        // Due to serialization
        public PlayerViewModel()
        {

        }
    }
}
