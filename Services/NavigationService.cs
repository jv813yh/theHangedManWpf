using theHangedManWpf.Stores;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Services
{
    public class NavigationService
    {
        private NavigationStore _navigationStore;
        private Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate() 
            => _navigationStore.CurrentViewModel = _createViewModel();
    }
}
