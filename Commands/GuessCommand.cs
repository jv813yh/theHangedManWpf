using System.ComponentModel;
using System.Windows.Input;
using theHangedManWpf.Services.GameEvaluationProviders;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    internal class GuessCommand : CommandBase, IDisposable
    {
        private readonly PlayingGameViewModel _playingGameViewModel;
        private readonly IGameEvaluationProvider _playingEvaluationProvider; 

        public GuessCommand(PlayingGameViewModel vieModel, 
            IGameEvaluationProvider gameEvaluationProvider)
        {
            _playingGameViewModel = vieModel;
            _playingEvaluationProvider = gameEvaluationProvider;

            _playingGameViewModel.PropertyChanged += OnViewModelChanged;
        }

        // Implementation IDisposable interface
        public void Dispose()
        {
            _playingGameViewModel.PropertyChanged -= OnViewModelChanged;
        }

        private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_playingGameViewModel.GuessInputString))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
            => base.CanExecute(parameter) && Char.IsLetter(_playingGameViewModel.GuessChar)
                && _playingGameViewModel.GuessInputString.Length < 2;

        public override void Execute(object? parameter)
        {
            //
            _playingEvaluationProvider.DoEvaluationGuessedWord(_playingGameViewModel.GuessChar);

            //
            _playingGameViewModel.ResultGuessWord = _playingEvaluationProvider.GetEditedGuessedWord;

            //
            _playingGameViewModel.AttemptsLeftViewModel = _playingEvaluationProvider.AttemptsLeft;

            //
            _playingGameViewModel.GuessInputString = string.Empty;

        }
    }
}
