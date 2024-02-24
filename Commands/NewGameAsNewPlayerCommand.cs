using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.Stores;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    public class NewGameAsNewPlayerCommand : CommandBase
    {
        private readonly GameManager _gameManager;

        public NewGameAsNewPlayerCommand(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void Execute(object? parameter)
        {


           // _gameManager.GetnavigationStore.CurrentViewModel = new LetsPlayViewModel(new NavigationService(_gameManager.GetnavigationStore) , _gameManager);
        }
    }
}
