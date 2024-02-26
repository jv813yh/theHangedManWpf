using theHangedManWpf.Services.PlayersWrittingProviders;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Commands
{
    public class WritePlayerToXmlCommand : CommandBase
    {
        private readonly WrittingPlayersToXML _writtingPlayersToXml;
        private readonly HighScoresViewModel _vieModel;

        public WritePlayerToXmlCommand(HighScoresViewModel vieModel, WrittingPlayersToXML writtingPlayersToXML)
        {
            _vieModel = vieModel;
            _writtingPlayersToXml = writtingPlayersToXML;
        }
        public override void Execute(object? parameter)
        {
            _vieModel.MapToPlayerViewModel();

            _writtingPlayersToXml.SerializationPlayer();
        }
    }
}
