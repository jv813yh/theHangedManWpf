using theHangedManWpf.Services.PlayersReadingProviders;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    public class LoadHighScoresPlayersCommand : CommandBase
    {
        private readonly string _connectionString;

        private readonly HighScoresViewModel _viewModel;
        private readonly ReadingPlayersFromXml _readingService;
        public LoadHighScoresPlayersCommand(HighScoresViewModel viewModel, string connectionString)
        {
            _connectionString = connectionString;

            _viewModel = viewModel;

            _readingService = new ReadingPlayersFromXml(_connectionString);

        }
        public override void Execute(object? parameter)
        {
            _viewModel.UpdatePlayers(_readingService.LoadPlayersFromXml());
        }
    }
}
