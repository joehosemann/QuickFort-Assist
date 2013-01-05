using System;
using System.Windows.Data;
using System.Globalization;
using QFA.Model;
using QFA.Utilities;

namespace QFA.Converters
{
    public class RowIndexConverter : IValueConverter
    {
        private IValueConverter _valueConverter;

        /// <summary>
        /// A value converter for formatting this value
        /// </summary>
        public IValueConverter ValueConverter
        {
            set
            {
                _valueConverter = value;
            }
        }


        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            // obtain the 'bound' property via the Row string indexer
            Row row = value as Row;
            string index = parameter as string;
            object propertyValue = row[index];

            // convert if required
            if (_valueConverter != null)
            {
                propertyValue = _valueConverter.Convert(propertyValue, targetType, parameter, culture);
            }

            return propertyValue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            object valueToConvert = value;

            // convert if required
            if (_valueConverter != null)
            {
                valueToConvert = _valueConverter.ConvertBack(valueToConvert, targetType, parameter, culture);
            }

            // inform the bound Row instance of the property value change
            return new PropertyValueChange(parameter as string, valueToConvert);
        }
    }

}
