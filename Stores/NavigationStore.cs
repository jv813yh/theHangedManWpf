using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Stores
{
    // The navigation store class with the current view model
    public class NavigationStore
    {
        // The current view model property 
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

        // The event to change the current view model
        public event Action CurrentViewModelChanged;

        // Method to Invoke the event 
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
