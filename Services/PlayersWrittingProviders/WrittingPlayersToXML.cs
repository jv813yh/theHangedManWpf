using System.IO;
using System.Windows;
using System.Xml.Serialization;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Services.PlayersWrittingProviders
{
    public class WrittingPlayersToXML : IWrittingPlayersToXml
    {
        private readonly string _connectionString;
        private IEnumerable<PlayerViewModel> _players;

        public WrittingPlayersToXML(IEnumerable<PlayerViewModel> PlayersToXml, string connectionString)
        {
            _connectionString = connectionString;
            _players = PlayersToXml;
        }

        public void SerializationPlayer()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(_players.GetType());

                using (StreamWriter sw = new StreamWriter(_connectionString))
                {
                    xmlSerializer.Serialize(sw, _players);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Oh No, something went wrong with writting players", "Error during writting players",
                    MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
