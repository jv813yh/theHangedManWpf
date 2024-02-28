using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using theHangedManWpf.Models;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    public class TimerTickCommand : CommandBase, IDisposable
    {
        private readonly GameManager _gameManager;
        private readonly PlayingGameViewModel _vieModel;

        private DispatcherTimer _timer;

        private NavigateCommand _navigateCommand;

        public TimerTickCommand(GameManager gameManager, PlayingGameViewModel viewModel, 
            DispatcherTimer? timer, NavigateCommand navigateCommand)
        {
            _gameManager = gameManager;
            _vieModel = viewModel;

            _timer = timer;
            _navigateCommand = navigateCommand;
        }
              
        public override void Execute(object? parameter)
        {
            if(_gameManager.CurrentGame.PlayerDifficulty.Contains("Hard"))
            {
                _timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };

                _timer.Tick += Timer_Tick;
                _timer.Start();
            }
        }

        // 
        private void Timer_Tick(object sender, EventArgs e)
        {
            _vieModel.LeftTime--;
            if (_vieModel.LeftTime == 0)
            {
                _timer.Stop();

                Dispose();

                _navigateCommand.Execute(null);
            }
        }

        // Implementation IDisposable interface
        public void Dispose()
        {
            _timer.Tick -= Timer_Tick;
        }
    }
}
