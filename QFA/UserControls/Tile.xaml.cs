using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QFA.Model;
using QFA.Utilities;

// COLOR THE IMAGE VIA http://wpffx.codeplex.com/

namespace QFA.UserControls
{
    public partial class Tile : UserControl
    {

        private Image _parentImage;
        private Border _parentBorder;
        private Canvas _parentCanvas;
        private Rectangle _parentRectangle;

        public Tile()
        {
            InitializeComponent();

            _parentImage = FindName("img") as Image;
            _parentBorder = FindName("border") as Border;
            _parentCanvas = FindName("LayoutRoot") as Canvas;
            _parentRectangle = FindName("overlay") as Rectangle;

            MouseMove += Tile_MouseMove;
            MouseLeftButtonDown += Tile_MouseLeftButtonDown;
            MouseLeftButtonUp += Tile_MouseLeftButtonUp;
            MouseLeave += Tile_MouseLeave;

            //Loaded += new RoutedEventHandler(Tile_Loaded);
        }

        void Tile_Loaded(object sender, RoutedEventArgs e)
        {
            Command = new Command().GetCommandByLetter((string)MainPage.XmlDataCollection[RowId][ColumnId.ToString()], MainPage.CurrentMode);
        }

        void Tile_MouseLeave(object sender, MouseEventArgs e)
        {
            _parentBorder.BorderThickness = new Thickness { Bottom = 0, Left = 0, Right = 0, Top = 0 };
            _parentRectangle.Fill = null;
        }

        void Tile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Update();
        }

        void Tile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.MouseDown = true;
            Update();
        }

        void Tile_MouseMove(object sender, MouseEventArgs e)
        {
            _parentRectangle.Fill = General.ColorConverter("66FFFFFF");
            _parentBorder.BorderBrush = General.ColorConverter("FFFF8C00");
            _parentBorder.BorderThickness = new Thickness { Bottom = 1, Left = 1, Right = 1, Top = 1 };
            if (MainPage.MouseDown)
            {
                Update();
            }
        }

        public void Update()
        {
            MainPage.XmlDataCollection[RowId][ColumnId.ToString()] = MainPage.CurrentLetter;
            Command = MainPage.CurrentCommand;
            //_parentBorder.Background = General.ColorConverter(Command.BackgroundColor);
        }


        public int Index { get; set; }


    }

    public partial class Tile : INotifyPropertyChanged
    {
        public double X
        {
            get { return (double)GetValue(Canvas.LeftProperty); }
            set
            {
                if ((double)GetValue(Canvas.LeftProperty) != value)
                {
                    SetValue(Canvas.LeftProperty, value);
                    RaisePropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get { return (double)GetValue(Canvas.TopProperty); }
            set
            {
                if ((double)GetValue(Canvas.TopProperty) != value)
                {
                    SetValue(Canvas.TopProperty, value);
                    RaisePropertyChanged("Y");
                }
            }
        }

        private int _rowId;
        public int RowId
        {
            get { return _rowId; }
            set
            {
                if (_rowId != value)
                {
                    _rowId = value;
                    RaisePropertyChanged("RowId");
                }
            }
        }

        private int _columnId;
        public int ColumnId
        {
            get { return _columnId; }
            set
            {
                if (_columnId != value)
                {
                    _columnId = value;
                    RaisePropertyChanged("ColumnId");
                }
            }
        }




        private Command _command;
        public Command Command
        {
            get { return _command; }
            set
            {
                if (_command != value)
                {
                    _command = value;
                    RaisePropertyChanged("Command");
                    //img = TileImage;
                    //Background = General.ColorConverter(_command.BackgroundColor);

                }
            }
        }

        public string Letter
        {
            get { return _command.Letter; }
            set { Command.Letter = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
                this.Width = MainPage.TileWidth;
                this.Height = MainPage.TileHeight;
            }
        }
    }
}