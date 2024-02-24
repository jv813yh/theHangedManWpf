using theHangedManWpf.Stores;

namespace theHangedManWpf.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
