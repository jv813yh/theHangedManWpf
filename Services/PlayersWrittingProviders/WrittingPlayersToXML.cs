using System.IO;
using System.Windows;
using System.Xml.Serialization;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Services.PlayersWrittingProviders
{
    public class WrittingPlayersToXML
    {
        private readonly string _connectionString;
        private IEnumerable<PlayerViewModel> Players;

        public WrittingPlayersToXML(IEnumerable<PlayerViewModel> PlayersToXml, string connectionString)
        {
            _connectionString = connectionString;
            Players = PlayersToXml;
        }

        public void SerializationPlayer()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(Players.GetType());

                using (StreamWriter sw = new StreamWriter(_connectionString))
                {
                    xmlSerializer.Serialize(sw, Players);
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
