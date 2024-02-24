using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using theHangedManWpf.Commands;
using theHangedManWpf.Models;
using theHangedManWpf.Services;

namespace theHangedManWpf.ViewModels
{
    public class LetsPlayViewModel: ViewModelBase, INotifyDataErrorInfo
    {

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private Dictionary<string, List<string>> _propertyToDictionaryErrors;

        private string _nickName = string.Empty;
        public string NickName
        {
            get => _nickName; 
            set
            {
                if (value != _nickName)
                {
                    _nickName = value;
                    OnPropertyChanged(nameof(NickName));
                }

                ClearErrors(nameof(NickName), nameof(NickName));

                if (NickName.Length < 3)
                {
                    AddErrors(nameof(NickName), "Username must be at least 3 characters long.");  
                }
            }
        }

        private void ClearErrors(string key, string propertyName)
        {
            _propertyToDictionaryErrors.Remove(key);

            OnErrorsChanged(propertyName);
        }

        private void AddErrors(string key, string error)
        {
            if(!_propertyToDictionaryErrors.ContainsKey(key))
            {
                _propertyToDictionaryErrors.Add(key, new List<string>());
            }

            _propertyToDictionaryErrors[key].Add(error);

            OnErrorsChanged(key);
        }
        private void OnErrorsChanged(string propertyName)
            => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        public bool HasErrors => _propertyToDictionaryErrors.Any();

        public IEnumerable GetErrors(string propertyName) 
            => _propertyToDictionaryErrors.GetValueOrDefault(propertyName, new List<string>());

        public ICommand PlayGameCommand { get; }

        public LetsPlayViewModel(NavigationService navigationService, GameManager gameManager)
        {
             PlayGameCommand = new LoadNickNameCommand(this, navigationService, gameManager.CurrentGame);

            _propertyToDictionaryErrors = new Dictionary<string, List<string>>();
        }
    }
}
