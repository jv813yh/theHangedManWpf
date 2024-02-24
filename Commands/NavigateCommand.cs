using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theHangedManWpf.Services;
using theHangedManWpf.ViewModels;

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
