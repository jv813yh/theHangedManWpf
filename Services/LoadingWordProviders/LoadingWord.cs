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
                if(!File.Exists(_connectionString))
                    throw new FileNotFoundException($"The file {_connectionString} cannot be found." +
                        $"\nThe file must be in the /bin/Debug/net8.0 folder");

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
                    MessageBox.Show($"Error reading file\nThe file {_connectionString} may be damaged or in a bad format", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return returnWords;
        }
    }
}
