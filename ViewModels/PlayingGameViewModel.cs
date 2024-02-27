using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.Services.GameEvaluationProviders;

namespace theHangedManWpf.ViewModels
{
    public class PlayingGameViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private GameManager _gameManager;

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

        private string _resultGuessWord;
        public string ResultGuessWord
        {
            get => _resultGuessWord;

            set
            {
                _resultGuessWord = value;
                OnPropertyChanged(nameof(ResultGuessWord));
            }
        }

        private string _guessInputString;

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

        public char GuessChar { get; set; }
        public ICommand GuessCommandVieModel { get; }


        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private Dictionary<string, List<string>> _propertyToDictionaryErrors;
        public bool HasErrors => _propertyToDictionaryErrors.Any();
        public IEnumerable GetErrors(string? propertyName)
            => _propertyToDictionaryErrors.GetValueOrDefault(propertyName, new List<string>());

        private void OnErrorsChanged(string propertyName)
            => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        private void AddErrors(string propertyName, string error)
        {
            if(!_propertyToDictionaryErrors.ContainsKey(propertyName))
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

        public PlayingGameViewModel(GameManager gameManager, 
            NavigationService winNavigationService, NavigationService lostNavigationService)
        {

            _gameManager = gameManager;

            IGameEvaluationProvider gameProvider = new GameEvaluationProvider(_gameManager, winNavigationService, lostNavigationService);

            GuessCommandVieModel = new GuessCommand(this, gameProvider);

            _propertyToDictionaryErrors = new Dictionary<string, List<string>>();

            MessageBox.Show($"{CurrentGuessWord}", "CurrentGuessWord", MessageBoxButton.OK);
        }
    }
}
