using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace theHangedManWpf.Converters
{
    public class TimerTickToVisibilityConverter : IValueConverter
    {

        // Verifies whether the difficulty is set to hard,
        // if so it returns visibility and the timer is displayed if it is not hidden
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string difficultyPlayerString)
            {
               return (difficultyPlayerString.Contains("Hard")) ? Visibility.Visible : Visibility.Hidden;
            }

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
