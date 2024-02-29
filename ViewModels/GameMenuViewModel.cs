using System.Windows;
using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;

namespace theHangedManWpf.ViewModels
{
    public class GameMenuViewModel: ViewModelBase
    {
        private Game _game;
        public ICommand PlayGameCommand { get; }
        public ICommand RulesOfGameCommand { get; }
        public ICommand DifficultyCommand { get; }
        public ICommand QuickCommand { get; }

        public event Action DifficultyCommandlChanged;

        public GameMenuViewModel(NavigationService navigationService, NavigationService rulesOfTheGameService, GameManager gameManager)
        {
            _game = gameManager.CurrentGame;

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
