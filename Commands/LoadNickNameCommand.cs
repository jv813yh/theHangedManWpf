using System.ComponentModel;
using System.Windows;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    public class LoadNickNameCommand : CommandBase
    {
        private readonly LetsPlayViewModel _letsPlayViewModel;
        private readonly NavigationService _navigationService;
        private readonly Game _game;

        public LoadNickNameCommand(LetsPlayViewModel letsPlayViewModel, 
            NavigationService navigationService, Game game)
        {
            _letsPlayViewModel = letsPlayViewModel;
            _navigationService = navigationService;
            _game = game;

            _letsPlayViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_letsPlayViewModel.NickName))
                OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter) 
            => (_letsPlayViewModel.NickName.Length < 3) ? false : true;

        public override void Execute(object? parameter)
        {
            _game.Player = new Player(_letsPlayViewModel.NickName);

            if(_game.Player != null & _game.CurrentWord != null)
            {
                _navigationService.Navigate();
            }
            else
            {
                MessageBox.Show("No player name was entered or word was not created\n" +
                    "Please, repeat it again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
