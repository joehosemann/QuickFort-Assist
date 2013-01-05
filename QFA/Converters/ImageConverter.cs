using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using QFA.Model;

namespace QFA.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //var command = new Command().GetCommandByLetter((string)value, MainPage.CurrentMode);
            var command = (Command) value;

            var a = command.Letter;
            var t = a;

            //var test = new Uri(MainPage.Tileset + command.ImagePath, UriKind.Relative);
            //var a = test;

            //return new BitmapImage(M)

            //return new BitmapImage(new Uri(MainPage.Tileset + command.ImagePath, UriKind.Relative));

            StreamResourceInfo sr = Application.GetResourceStream(new Uri("QFA;component/" + MainPage.Tileset + command.ImagePath, UriKind.Relative));
            //StreamResourceInfo sr = Application.GetResourceStream(new Uri("QFA;';component/tileset_03.png", UriKind.Relative));
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(sr.Stream);

            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
