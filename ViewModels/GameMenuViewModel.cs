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
        public ICommand DifficultyCommand { get; }
        public ICommand HighScoresCommand { get; }
        public ICommand QuickCommand { get; }

        public GameMenuViewModel(NavigationService navigationService, GameManager gameManager)
        {
            _game = gameManager.CurrentGame;

            DifficultyCommand = new RelayCommand<string>(ExecuteMethod, CanExecuteMethod);

            PlayGameCommand = new NavigateCommand(navigationService);

            QuickCommand = new CloseGameCommand();
        }

        // I have IsChecked="True" for RadioButton but I use function CanExecuteMethod for verify it
        private bool CanExecuteMethod(object parameter) 
            => (parameter != null) ? true : false;

        
        private void ExecuteMethod(object parameter)
        {
            try
            {
                _game.PlayerDifficulty = Convert.ToString(parameter);
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
