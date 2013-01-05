using System.Collections.ObjectModel;
using System.Windows;
using QFA.UserControls;

namespace QFA.Model
{
    public class Data : ObservableCollection<Tile>
    {
        public Data()
        {
            this.CollectionChanged += collectionChanged;
        }

        void collectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var tiles = (ObservableCollection<Tile>)sender;
            if (tiles.Count != 0)
            {
                var tile = (Tile) e.NewItems[0];
         
                if (e.Action.ToString() == "Add")
                {
                    MainPage.ParentCanvas.Children.Add(tile);
                }
                else
                {
                    MessageBox.Show(e.Action.ToString());
                }
            }
        }

        
    }


}
