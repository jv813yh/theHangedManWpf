using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace theHangedManWpf.Converters
{
    public class ErrorCountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int attempLeft)
            {
                string? parameterString = parameter as string;

                if (parameterString != null)
                {
                    try
                    {
                        int imageIndex; 

                        if (int.TryParse(parameterString, out imageIndex))
                        {
                            // If the image index is greater than the number of attempts, we display the image
                            return (imageIndex > attempLeft) ? Visibility.Visible : Visibility.Hidden;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Failed to pass parameter to int due to invalid format, restart game please", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Restart game please", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            // We return the default visibility value if the conversion failed
            return Visibility.Hidden;
        }

        /// <summary>
        /// I do not use this function, but I have to implement due to IValueConverter
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
