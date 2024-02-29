using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.Services.GameEvaluationProviders;

namespace theHangedManWpf.ViewModels
{
    public class PlayingGameViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private GameManager _gameManager;

        private DispatcherTimer? _timer;

        private int _remainingTime = 15;
        public int RemainingTime
        {
            get => _remainingTime;

            set
            {
                _remainingTime = value;
                OnPropertyChanged(nameof(RemainingTime));
            }
        }

        private int _attemptsLeftViewModel = 11;
        public int AttemptsLeftViewModel
        { 
            get => _attemptsLeftViewModel;
            set
            {
                _attemptsLeftViewModel = value;
                OnPropertyChanged(nameof(AttemptsLeftViewModel));
            }
        }
        public string CurrentGuessWord 
            => _gameManager.CurrentGame.CurrentWord.GuessWord;

        private string _resultGuessWord = "";
        public string ResultGuessWord
        {
            get => _resultGuessWord;

            set
            {
                _resultGuessWord = value;
                OnPropertyChanged(nameof(ResultGuessWord));
            }
        }

        private string _guessInputString = "";

        public string GuessInputString
        {
            get { return _guessInputString; }
            set
            {
                try
                {
                    _guessInputString = value;

                    if(!string.IsNullOrEmpty(_guessInputString))
                        GuessChar = char.ToUpper(value[0]);

                    OnPropertyChanged(nameof(GuessInputString));

                    ClearErrors(nameof(GuessInputString));

                    if (GuessInputString.Length > 1 )
                    {
                        AddErrors(nameof(GuessInputString), "Enter only one letter.");
                    }

                    if (Char.IsDigit(GuessChar))
                    {
                        AddErrors(nameof(GuessInputString), "Why are you entering numbers ?");
                    }

                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Global exception", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string _playerDifficulty;
        public string PlayerDifficulty
        {
            get => _playerDifficulty;

            set => _playerDifficulty = value;
        }

        public char GuessChar { get; set; }
        public ICommand GuessCommandVieModel { get; }
        public ICommand TimeTickerCommand { get; }
        public ICommand NewGameCommand { get; }

        public PlayingGameViewModel(GameManager gameManager, 
            NavigationService winNavigationService, NavigationService lostNavigationService, NavigationService NewGameService)
        {

            _gameManager = gameManager;

            IGameEvaluationProvider gameProvider = new GameEvaluationProvider(_gameManager, winNavigationService, lostNavigationService);

            GuessCommandVieModel = new GuessCommand(this, gameProvider);

            _propertyToDictionaryErrors = new Dictionary<string, List<string>>();

            NewGameCommand = new NewGameCommad(_gameManager, new NavigateCommand(NewGameService));

            TimeTickerCommand = new TimerTickCommand(_gameManager, this, _timer ,new NavigateCommand(lostNavigationService));

            MessageBox.Show($"{CurrentGuessWord}", "CurrentGuessWord", MessageBoxButton.OK);

        }

        public static PlayingGameViewModel ReturnPlayingGameViewModel(GameManager gameManager, 
                       NavigationService winNavigationService, NavigationService lostNavigationService, NavigationService NewGameService)
        {
            PlayingGameViewModel returnViewModel = new PlayingGameViewModel(gameManager, winNavigationService, lostNavigationService, NewGameService);

            returnViewModel.SetDifficultyForProperty();
            returnViewModel.TimeTickerCommand.Execute(null);


            return returnViewModel;
        }

        public void SetDifficultyForProperty()
        {
            _playerDifficulty = _gameManager.CurrentGame.PlayerDifficulty;
        }


        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private Dictionary<string, List<string>> _propertyToDictionaryErrors;
        public bool HasErrors => _propertyToDictionaryErrors.Any();
        public IEnumerable GetErrors(string? propertyName)
            => _propertyToDictionaryErrors.GetValueOrDefault(propertyName, new List<string>());

        private void OnErrorsChanged(string propertyName)
            => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        private void AddErrors(string propertyName, string error)
        {
            if (!_propertyToDictionaryErrors.ContainsKey(propertyName))
            {
                _propertyToDictionaryErrors.Add(propertyName, new List<string>());
            }

            _propertyToDictionaryErrors[propertyName].Add(error);

            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            _propertyToDictionaryErrors.Remove(propertyName);

            OnErrorsChanged(propertyName);
        }
    }
}
