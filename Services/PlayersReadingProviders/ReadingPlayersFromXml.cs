using System.IO;
using System.Windows;
using System.Xml.Serialization;
using theHangedManWpf.ViewModels;

namespace theHangedManWpf.Services.PlayersReadingProviders
{
    public class ReadingPlayersFromXml
    {
        private readonly string _connectionString;

        public ReadingPlayersFromXml(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PlayerViewModel>? LoadPlayersFromXml()
        {
            List<PlayerViewModel> players = new List<PlayerViewModel>();
            
            try
            {
                if(File.Exists(_connectionString))
                {
                    XmlSerializer serializer = new XmlSerializer(players.GetType());

                    using (StreamReader sr = new StreamReader(_connectionString))
                    {
                        players = (List<PlayerViewModel>)serializer.Deserialize(sr);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Oh No, something wrong with reading players", "Error during reading players",
                    MessageBoxButton.OK, MessageBoxImage.None);
            }

            return players;
        }
    }
}
