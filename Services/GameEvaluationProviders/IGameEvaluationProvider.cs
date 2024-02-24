using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theHangedManWpf.Models;

namespace theHangedManWpf.Services.GameEvaluationProviders
{
    public interface IGameEvaluationProvider
    {
        int AttemptsLeft { get; set; }
        string GetEditedGuessedWord { get; set; }
        void DoEvaluationGuessedWord(char guessedChar);
        void EditedGuessedWord();
    }
}
