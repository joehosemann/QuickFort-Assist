﻿using System.Collections.Generic;
using System.ComponentModel;
using QFA.Utilities;

namespace QFA.Model
{
    /// <summary>
    /// Represents a dynamic row of data
    /// </summary>
    public class Row : INotifyPropertyChanged
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();

        /// <summary>
        /// Gets the column names
        /// </summary>
        public ICollection<string> ColumnNames
        {
            get
            {
                return _data.Keys;
            }
        }
        /// <summary>
        /// a string indexer for accessing the rows properties
        /// </summary>
        public object this[string index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;

                // any property changes need to be signalled to UI elements bound to the Data property
                OnPropertyChanged("Data");
            }
        }

        /// <summary>
        /// A property which is used for integrating with the binding framework.
        /// </summary>
        public object Data
        {
            get
            {
                // when the binding framework reads this property, simple return the Row instance. The
                // RowIndexConverter takes care of extracting the correct property value
                return this;
            }
            set
            {
                // the RowIndexConverter will signal property changes by providing an instance of PropertyValueChange.
                PropertyValueChange setter = value as PropertyValueChange;
                _data[setter.PropertyName] = setter.Value;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
}