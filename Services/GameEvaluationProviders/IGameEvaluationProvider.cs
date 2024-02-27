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
