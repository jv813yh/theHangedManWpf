namespace theHangedManWpf.Services.LoadingWordProviders
{
    public interface ILoadingWords
    {
        string ConnectionString { get; }
        Dictionary<int, string> GetGuessingWord();
    }
}
