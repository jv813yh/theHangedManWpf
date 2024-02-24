using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theHangedManWpf.Models;
using theHangedManWpf.Services;

namespace theHangedManWpf.ViewModels
{
    public class HighScoresViewModel : ViewModelBase
    {
        private readonly GameManager _gameManager;

        public HighScoresViewModel(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
    }
}
