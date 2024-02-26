using theHangedManWpf.Models;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
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

        private void OnDiDifficultyCommandChangedObserver()
        {
            OnCanExecuteChanged();
        }
        
        public override bool CanExecute(object? parameter)
            => !string.IsNullOrEmpty(_gameManager.CurrentGame.PlayerDifficulty);

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
