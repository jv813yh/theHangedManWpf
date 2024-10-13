using System.IO;
using System.Windows;

namespace theHangedManWpf.Services.LoadingWordProviders
{
    public class LoadingWords : ILoadingWords
    {
        public string ConnectionString { get; }
        public LoadingWords(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Dictionary<int, string> GetGuessingWord()
        {
            Dictionary<int, string> returnWords = new Dictionary<int, string>();
            int numberKey = 0;

            try
            {
                // If file does not exist we will add default words 
                if(!File.Exists(ConnectionString))
                {
                    returnWords.Add(numberKey++, string.Empty);
                }
                else
                {
                    using (StreamReader sr = new StreamReader(ConnectionString))
                    {
                        string line;
                        // we can use StringBuilder but input file is not too big and we do not need 
                        // some aditional work with string ...
                        while ((line = sr.ReadLine()) != null)
                        {
                            returnWords.Add(numberKey++, line.ToUpper());
                        }
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show($"Error reading file\nThe file {ConnectionString} may be damaged or in a bad format", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return returnWords;
        }
    }
}
