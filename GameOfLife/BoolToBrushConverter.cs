using System.Windows.Data;
using System.Windows.Media;

namespace GameOfLife
{
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (bool)value;
            if (val)
                return new SolidColorBrush(Colors.Green);

            return new SolidColorBrush(Colors.LightGray);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}