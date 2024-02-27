using theHangedManWpf.Models;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    // Command class to verify if the difficulty was set and navigate to the next view
    public class VerifySetDifficultyCommand : CommandBase, IDisposable
    {
        private readonly GameManager _gameManager;
        private readonly GameMenuViewModel _menuViewModel;
        private readonly NavigateCommand _navigateCommand;

        public VerifySetDifficultyCommand(GameManager gameManager, GameMenuViewModel viewModel, NavigateCommand navigateCommand)
        {

            _gameManager = gameManager;
            _navigateCommand = navigateCommand;
            _menuViewModel = viewModel;

            _menuViewModel.DifficultyCommandlChanged += OnDiDifficultyCommandChangedObserver;
        }

        // Observer to verify if the difficulty was set
        private void OnDiDifficultyCommandChangedObserver()
        {
            OnCanExecuteChanged();
        }
        
        // Verify if the difficulty was set
        public override bool CanExecute(object? parameter)
            => !string.IsNullOrEmpty(_gameManager.CurrentGame.PlayerDifficulty);

        // Navigate to the next view
        public override void Execute(object? parameter)
        {
            _navigateCommand.Execute(parameter);

            Dispose();
        }

        // Implementation IDisposable interface
        public void Dispose()
        {
            _menuViewModel.DifficultyCommandlChanged -= OnDiDifficultyCommandChangedObserver;
        }
    }
}
