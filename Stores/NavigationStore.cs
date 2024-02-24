using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        {
            get => _currentViewModel;
            set
            {
                if(value != _currentViewModel)
                {
                    _currentViewModel = value;
                    OnCurrentViewModelChanged();
                }
            }
        }

        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
