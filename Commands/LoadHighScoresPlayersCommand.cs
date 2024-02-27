using theHangedManWpf.Services.PlayersReadingProviders;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    public class LoadHighScoresPlayersCommand : CommandBase
    {
        private readonly HighScoresViewModel _viewModel;
        private readonly IReadingPlayersFromXml _readingService;
        public LoadHighScoresPlayersCommand(HighScoresViewModel viewModel, string connectionString)
        {
            _viewModel = viewModel;

            // Create the service to read the players from the xml file
            _readingService = new ReadingPlayersFromXml(connectionString);
        }

        // Added the players from the xml file to the list
        public override void Execute(object? parameter)
        {
            _viewModel.UpdatePlayers(_readingService.LoadPlayersFromXml());
        }
    }
}
