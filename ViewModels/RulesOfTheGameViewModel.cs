using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Services;

namespace theHangedManWpf.ViewModels
{
    public class RulesOfTheGameViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }
        public RulesOfTheGameViewModel(NavigationService gameMenuViewModelService)
        {
            NavigateCommand =  new NavigateCommand(gameMenuViewModelService);
        }
    }
}
