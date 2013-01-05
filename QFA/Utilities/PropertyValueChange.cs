namespace QFA.Utilities
{
    /// <summary>
    /// A simple class used to communicate property value changes to a Row
    /// </summary>
    public class PropertyValueChange
    {
        private string _propertyName;

        private object _value;

        public object Value
        {
            get { return _value; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public PropertyValueChange(string propertyName, object value)
        {
            _propertyName = propertyName;
            _value = value;
        }
    }
}
