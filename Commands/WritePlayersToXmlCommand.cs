using theHangedManWpf.Services.PlayersWrittingProviders;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    /// <summary>
    /// Command class to write the players to the xml file
    /// </summary>
    public class WritePlayersToXmlCommand : CommandBase
    {
        // private readonly WrittingPlayersToXML _writtingPlayersToXml;
        private readonly IWrittingPlayersToXml _writtingPlayersToXml;

        // private readonly HighScoresViewModel _viewModel;
        private readonly HighScoresViewModel _vieModel;

        public WritePlayersToXmlCommand(HighScoresViewModel vieModel, IWrittingPlayersToXml writtingPlayersToXML)
        {
            _vieModel = vieModel;
            _writtingPlayersToXml = writtingPlayersToXML;
        }

        /// <summary>
        /// Execute the command to map the players to the playerViewModel, 
        /// add playerViewModel to the list
        /// and write the players to the xml file
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            // Map the players to the view model and add playerViewModel to the list
            _vieModel.MapToPlayerViewModel();

            // Write the players to the xml file
            _writtingPlayersToXml.SerializationPlayer();
        }
    }
}
