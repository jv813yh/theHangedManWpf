using System.Windows;
using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;

namespace theHangedManWpf.ViewModels
{
    public class GameMenuViewModel: ViewModelBase
    {
        private readonly string _connectionString;
        private bool _isGameStartedValid = true;
        private Game _game;
        public ICommand PlayGameCommand { get; }
        public ICommand RulesOfGameCommand { get; }
        public ICommand DifficultyCommand { get; }
        public ICommand QuickCommand { get; }

        public event Action DifficultyCommandlChanged;

        public GameMenuViewModel(NavigationService navigationService, NavigationService rulesOfTheGameService, GameManager gameManager)
        {
            _game = gameManager.CurrentGame;
            _isGameStartedValid = gameManager.IsGameStartedValid;
            _connectionString = gameManager.ConnectionString;

            DifficultyCommand = new RelayCommand<string>(ExecuteMethod);

            PlayGameCommand = new VerifySetDifficultyCommand(gameManager, this, new NavigateCommand(navigationService));

            RulesOfGameCommand = new NavigateCommand(rulesOfTheGameService);

            QuickCommand = new CloseGameCommand();
        }

        private void OnDifficultyCommandlChanged()
        {
            DifficultyCommandlChanged?.Invoke();
        }
        private void ExecuteMethod(object parameter)
        {
            try
            {
                if(!_isGameStartedValid)
                {
                    MessageBox.Show("Application read the input words incorrectly, the application works in crisis mode.\n" +
                        $"Please, check the file on this path {_connectionString} \n" +
                        "it must contain the guessed words", "Error", 
                                               MessageBoxButton.OK, MessageBoxImage.Error);
                }

                _game.PlayerDifficulty = Convert.ToString(parameter);

                OnDifficultyCommandlChanged();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("It is not possible to set the difficulty, let's set the default value to Easy", "Default value",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                _game.PlayerDifficulty = "Easy";
            }
            catch (Exception)
            {
                MessageBox.Show("It is not possible to set the difficulty, please restart the game", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
