using System.IO;
using System.Windows;

namespace theHangedManWpf.Services.LoadingWordProviders
{
    public class LoadingWord : ILoadingWord
    {
        private string _connectionString;

        public LoadingWord(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Dictionary<int, string> GetGuessingWord()
        {
            Dictionary<int, string> returnWords = new Dictionary<int, string>();

            int numberKey = 0;

            using(StreamReader sr = new StreamReader(_connectionString))
            {
                try
                {
                    string line;
                    // we can use StringBuilder but input file is not too big and we do not need 
                    // some aditional work with string ...
                    while((line = sr.ReadLine()) != null)
                    {
                        returnWords.Add(numberKey++, line.ToUpper());
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Error reading file", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return returnWords;
        }
    }
}
