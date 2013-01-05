using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using QFA.Model;

namespace QFA.Utilities
{
    // ICollectionView implementation courtesy of the following blog post:
    // http://weblogs.asp.net/manishdalal/archive/2008/12/30/silverlight-datagrid-custom-sorting.aspx
    //
    // The Refresh() method has been modified to sort by our Row class via its 
    // string indexer.
    public class SortableCollectionView : ObservableCollection<Row>, ICollectionView
    {
        private CultureInfo _culture;
        private object _currentItem;

        private int _currentPosition;
        private CustomSortDescriptionCollection _sort;

        private bool _suppressCollectionChanged;


        public SortableCollectionView()
        {
            _currentItem = null;
            _currentPosition = -1;
        }

        protected bool IsCurrentInSync
        {
            get
            {
                if (IsCurrentInView)
                {
                    return (GetItemAt(CurrentPosition) == CurrentItem);
                }

                return (CurrentItem == null);
            }
        }

        private bool IsCurrentInView
        {
            get { return ((0 <= CurrentPosition) && (CurrentPosition < Count)); }
        }

        #region ICollectionView Members

        public bool CanFilter
        {
            get { return false; }
        }

        public bool CanGroup
        {
            get { return false; }
        }

        public bool CanSort
        {
            get { return true; }
        }

        public bool Contains(object item)
        {
            if (!IsValidType(item))
            {
                return false;
            }

            return Contains(item);
        }

        public CultureInfo Culture
        {
            get { return _culture; }
            set
            {
                if (_culture != value)
                {
                    _culture = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Culture"));
                }
            }
        }

        public event EventHandler CurrentChanged;

        public event CurrentChangingEventHandler CurrentChanging;

        public object CurrentItem
        {
            get { return _currentItem; }
        }

        public int CurrentPosition
        {
            get { return _currentPosition; }
        }

        public IDisposable DeferRefresh()
        {
            return new SortableCollectionDeferRefresh(this);
        }

        public Predicate<object> Filter { get; set; }

        public ObservableCollection<GroupDescription> GroupDescriptions
        {
            get { throw new NotImplementedException(); }
        }

        public ReadOnlyObservableCollection<object> Groups
        {
            get
            {
                return new ReadOnlyObservableCollection<object>(
                    new ObservableCollection<object>());
            }
        }

        public bool IsCurrentAfterLast
        {
            get
            {
                if (!IsEmpty)
                {
                    return (CurrentPosition >= Count);
                }
                return true;
            }
        }

        public bool IsCurrentBeforeFirst
        {
            get
            {
                if (!IsEmpty)
                {
                    return (CurrentPosition < 0);
                }
                return true;
            }
        }

        public bool IsEmpty
        {
            get { return (Count == 0); }
        }

        public bool MoveCurrentTo(object item)
        {
            if (!IsValidType(item))
            {
                return false;
            }

            if (Equals(CurrentItem, item) && ((item != null) || IsCurrentInView))
            {
                return IsCurrentInView;
            }

            int index = IndexOf((Row) item);

            return MoveCurrentToPosition(index);
        }

        public bool MoveCurrentToFirst()
        {
            return MoveCurrentToPosition(0);
        }

        public bool MoveCurrentToLast()
        {
            return MoveCurrentToPosition(Count - 1);
        }

        public bool MoveCurrentToNext()
        {
            return ((CurrentPosition < Count) && MoveCurrentToPosition(CurrentPosition + 1));
        }

        public bool MoveCurrentToPrevious()
        {
            return ((CurrentPosition >= 0) && MoveCurrentToPosition(CurrentPosition - 1));
        }

        public bool MoveCurrentToPosition(int position)
        {
            if ((position < -1) || (position > Count))
            {
                throw new ArgumentOutOfRangeException("position");
            }

            if (((position != CurrentPosition) || !IsCurrentInSync) && OKToChangeCurrent())
            {
                bool isCurrentAfterLast = IsCurrentAfterLast;
                bool isCurrentBeforeFirst = IsCurrentBeforeFirst;

                ChangeCurrentToPosition(position);

                OnCurrentChanged();

                if (IsCurrentAfterLast != isCurrentAfterLast)
                {
                    OnPropertyChanged("IsCurrentAfterLast");
                }

                if (IsCurrentBeforeFirst != isCurrentBeforeFirst)
                {
                    OnPropertyChanged("IsCurrentBeforeFirst");
                }

                OnPropertyChanged("CurrentPosition");
                OnPropertyChanged("CurrentItem");
            }

            return IsCurrentInView;
        }

        public void Refresh()
        {
            IEnumerable<Row> rows = this;
            IOrderedEnumerable<Row> orderedRows = null;

            // use the OrderBy and ThenBy LINQ extension methods to
            // sort our data
            bool firstSort = true;
            for (int sortIndex = 0; sortIndex < _sort.Count; sortIndex++)
            {
                SortDescription sort = _sort[sortIndex];
                Func<Row, object> function = row => row[sort.PropertyName];
                if (firstSort)
                {
                    orderedRows = sort.Direction == ListSortDirection.Ascending
                                      ? rows.OrderBy(function)
                                      : rows.OrderByDescending(function);

                    firstSort = false;
                }
                else
                {
                    orderedRows = sort.Direction == ListSortDirection.Ascending
                                      ? orderedRows.ThenBy(function)
                                      : orderedRows.ThenByDescending(function);
                }
            }

            _suppressCollectionChanged = true;

            // re-order this collection based on the result if the above
            int index = 0;
            if (orderedRows != null)
                foreach (Row row in orderedRows)
                {
                    this[index++] = row;
                }

            _suppressCollectionChanged = false;

            // raise the required notification
            OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public SortDescriptionCollection SortDescriptions
        {
            get
            {
                if (_sort == null)
                {
                    SetSortDescriptions(new CustomSortDescriptionCollection());
                }
                return _sort;
            }
        }

        public IEnumerable SourceCollection
        {
            get { return this; }
        }

        #endregion

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (_suppressCollectionChanged)
                return;

            base.OnCollectionChanged(e);
        }


        protected override void InsertItem(int index, Row item)
        {
            base.InsertItem(index, item);

            if (0 == index || null == _currentItem)
            {
                _currentItem = item;
                _currentPosition = index;
            }
        }

        public virtual object GetItemAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                return this[index];
            }

            return null;
        }

        private bool IsValidType(object item)
        {
            return item is Row;
        }

        private void ChangeCurrentToPosition(int position)
        {
            if (position < 0)
            {
                _currentItem = null;
                _currentPosition = -1;
            }
            else if (position >= Count)
            {
                _currentItem = null;
                _currentPosition = Count;
            }
            else
            {
                _currentItem = this[position];
                _currentPosition = position;
            }
        }

        protected bool OKToChangeCurrent()
        {
            var args = new CurrentChangingEventArgs();
            OnCurrentChanging(args);
            return !args.Cancel;
        }

        protected virtual void OnCurrentChanged()
        {
            if (CurrentChanged != null)
            {
                CurrentChanged(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCurrentChanging(CurrentChangingEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            if (CurrentChanging != null)
            {
                CurrentChanging(this, args);
            }
        }

        protected void OnCurrentChanging()
        {
            _currentPosition = -1;
            OnCurrentChanging(new CurrentChangingEventArgs(false));
        }

        protected override void ClearItems()
        {
            OnCurrentChanging();
            base.ClearItems();
        }

        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void SetSortDescriptions(CustomSortDescriptionCollection descriptions)
        {
            if (_sort != null)
            {
                _sort.MyCollectionChanged -= SortDescriptionsChanged;
            }

            _sort = descriptions;

            if (_sort != null)
            {
                _sort.MyCollectionChanged += SortDescriptionsChanged;
            }
        }

        private void SortDescriptionsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove && e.NewStartingIndex == -1 &&
                SortDescriptions.Count > 0)
            {
                return;
            }
            if (((e.Action != NotifyCollectionChangedAction.Reset) || (e.NewItems != null))
                || (((e.NewStartingIndex != -1) || (e.OldItems != null)) || (e.OldStartingIndex != -1)))
            {
                Refresh();
            }
        }
    }

    public class SortableCollectionDeferRefresh : IDisposable
    {
        private readonly SortableCollectionView _collectionView;

        internal SortableCollectionDeferRefresh(SortableCollectionView collectionView)
        {
            _collectionView = collectionView;
        }

        #region IDisposable Members

        public void Dispose()
        {
            // refresh the collection when disposed.
            _collectionView.Refresh();
        }

        #endregion
    }


    public class CustomSortDescriptionCollection : SortDescriptionCollection
    {
        public event NotifyCollectionChangedEventHandler MyCollectionChanged
        {
            add { CollectionChanged += value; }
            remove { CollectionChanged -= value; }
        }
    }
}