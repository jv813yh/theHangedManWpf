﻿using System.ComponentModel;
using System.Windows;
using theHangedManWpf.Models;
using theHangedManWpf.Services;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    public class LoadNickNameCommand : CommandBase, IDisposable
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

        // Check if the NickName property has changed
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_letsPlayViewModel.NickName))
                OnCanExecuteChanged();
        }

        // Check if the NickName property has at least 3 characters
        public override bool CanExecute(object? parameter) 
            => (_letsPlayViewModel.NickName.Length < 3) ? false : true;

        // Execute the command to create a new player and navigate to the PlayingGameView
        public override void Execute(object? parameter)
        {
            _game.Player = new Player(_letsPlayViewModel.NickName);

            if(_game.Player != null & _game.CurrentWord != null)
            {
                _navigationService.Navigate();

                Dispose();
            }
            else
            {
                MessageBox.Show("No player name was entered or word was not created\n" +
                    "Please, repeat it again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Implementation IDisposable interface
        public void Dispose()
        {
            _letsPlayViewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }
    }
}
