using theHangedManWpf.Models;
using theHangedManWpf.Services;

namespace theHangedManWpf.Commands
{
    public class NewGameCommad : CommandBase
    {
        private readonly GameManager _gameManager;
        private readonly CreateViewModelsService _createViewModelsServiceService;
        private readonly NavigateCommand _navigateCommand;

        public NewGameCommad(GameManager gameManager, NavigateCommand navigateCommand)
        {
            _gameManager = gameManager;

            _navigateCommand = navigateCommand;
        }

        public override void Execute(object? parameter)
        {
            _gameManager.StartNewGame();

            _navigateCommand.Execute(parameter);
        }
    }
}
