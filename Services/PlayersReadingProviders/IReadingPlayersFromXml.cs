using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Services.PlayersReadingProviders
{
    public interface IReadingPlayersFromXml
    {
        List<PlayerViewModel>? LoadPlayersFromXml();
    }
}
