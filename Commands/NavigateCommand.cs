using theHangedManWpf.Services;

namespace theHangedManWpf.Commands
{
    public class NavigateCommand : CommandBase
    {
        private NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
