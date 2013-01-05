using System;
using System.Windows.Media;

namespace QFA.Utilities
{
    public class General
    {
        public static SolidColorBrush ColorConverter(string s)
        {
            byte a = Convert.ToByte(s.Substring(0, 2), 16);
            byte r = Convert.ToByte(s.Substring(2, 2), 16);
            byte g = Convert.ToByte(s.Substring(4, 2), 16);
            byte b = Convert.ToByte(s.Substring(6, 2), 16);
            var color =  Color.FromArgb(a, r, g, b);
            return new SolidColorBrush(color);
        }



    }
}
