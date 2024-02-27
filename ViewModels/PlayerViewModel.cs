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
            get => _name;

            set => _name = value;
        }
        private string _guessedWord;

        public string GuessedWord
        {
            get => _guessedWord;

            set => _guessedWord = value;
        }
        private int _countOfMistakes;

        public int CountOfMistakes
        {
            get => _countOfMistakes;

            set => _countOfMistakes = value;
        }

        private string _playerDifficulty;
        public string PlayerDifficulty
        {
            get => _playerDifficulty;

            set => _playerDifficulty =  value;
        }
       
        public PlayerViewModel(Game game)
        {
            _game = game;

            InitializeProperties(game);
        }

        // Due to serialization
        public PlayerViewModel()
        {

        }

        private void InitializeProperties(Game currentgame)
        {
            if(_game != null)
            {
                _name = currentgame.Player.NickName;
                _guessedWord = currentgame.CurrentWord.GuessWord;
                _countOfMistakes = currentgame.CurrentWord.CountOfMistakes;
                _playerDifficulty = currentgame.PlayerDifficulty;
            }
        }
    }
}
