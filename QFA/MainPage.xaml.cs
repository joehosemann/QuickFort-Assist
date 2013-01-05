#region Assemblies
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;
using QFA.Converters;
using QFA.Model;
using QFA.UserControls;
using QFA.Utilities;
#endregion

namespace QFA
{
    public partial class MainPage
    {
        #region Properties / Fields
       
        // Options
        public static int TileWidth = 16;
        public static int TileHeight = 16;
        public static string TilesetPath = @"Images";

        // Parent Objects
        public static Canvas ParentCanvas;
        public static ListBox ParentListBox;
        public static DataGrid ParentDataGrid;
        public static ComboBox ParentComboBox;

        // DataGrid
        private static SortableCollectionView _designationData;
        private static SortableCollectionView _buildData;
        private static XDocument _designationXmlData;
        private static XDocument _buildXmlData;
        public static bool MouseDown;
        private static int _currentMode;
        private static Command _currentCommand;
        public static string Tileset = TilesetPath + @"/phoebus/";
        public static int Rows = 20;
        public static int Columns = 20;
        private readonly RowIndexConverter _rowIndexConverter = new RowIndexConverter();
        public static SortableCollectionView XmlDataCollection
        {
            get
            {
                if (CurrentMode == 0)
                    return _designationData;
                return _buildData;
            }
            set
            {
                if (CurrentMode == 0)
                    _designationData = value;
                else
                    _buildData = value;
            }
        }
        public static XDocument XmlDocumentData
        {
            get
            {
                if (CurrentMode == 0)
                    return _designationXmlData;
                else
                    return _buildXmlData;
            }
            set
            {
                if (CurrentMode == 0)
                    _designationXmlData = value;
                else
                    _buildXmlData = value;
            }
        }

        // Other
        public static Data Tiles
        {
            get
            {
                if (CurrentMode == 0)
                    return _designationTiles;
                else
                    return _buildTiles;
            }
            set
            {
                if (CurrentMode == 0)
                    _designationTiles = value;
                else
                    _buildTiles = value;
            }
        }
        public static Data _designationTiles { get; set; }
        public static Data _buildTiles { get; set; }
        public static int CurrentMode
        {
            get { return _currentMode; }
            set
            {
                if (value != _currentMode)
                {
                    if (value == 0)
                        ParentComboBox.SelectedIndex = 0;
                    else
                        ParentComboBox.SelectedIndex = 1;
                    _currentMode = value;
                }
            }
        }
        public static int CurrentIndex
        {
            get { return CurrentCommand.Index; }
        }
        public static string CurrentLetter
        {
            get { return CurrentCommand.Letter; }
        }
        public static Command CurrentCommand
        {
            get { return _currentCommand; }
            set
            {
                if (ParentListBox.Items.Count != 0 && value != null)
                    ParentListBox.SelectedValue = value.Name;
                _currentCommand = value;
            }
        }

        #endregion

        public MainPage()
        {
            InitializeComponent();

            ParentCanvas = FindName("canvasMain") as Canvas;
            ParentListBox = FindName("lbMenu") as ListBox;
            ParentDataGrid = FindName("dgXml") as DataGrid;
            ParentComboBox = FindName("cbMenu") as ComboBox;

            CurrentCommand = Command.Commands[0];

            // Creates Xml.
            _designationXmlData = new XmlFactory().PopulateXmlDataGrid(Rows, Columns, "data", Command.Commands[0].Letter);
            _buildXmlData = new XmlFactory().PopulateXmlDataGrid(Rows, Columns, "data", Command.Commands[62].Letter);

            // Sends stored Xml to be parsed and sorted into collection
            _designationData = new XmlFactory().ConvertXmlToSortableCollectionView(_designationXmlData);
            _buildData = new XmlFactory().ConvertXmlToSortableCollectionView(_buildXmlData);


            _designationTiles = new Data();
            _buildTiles = new Data();

            DataGridXmlUpdate();

            InitializeTiles();
        }

        #region Events

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            canvasMain.MouseLeftButtonDown += canvasMain_MouseLeftButtonDown;
            canvasMain.MouseLeftButtonUp += canvasMain_MouseLeftButtonUp;
            canvasMain.MouseLeave += canvasMain_MouseLeave;
            canvasMain.MouseEnter += canvasMain_MouseEnter;
            KeyDown += MainPage_KeyDown;
            cbMenu.SelectionChanged += cbMenu_SelectionChanged;
            lbMenu.SelectionChanged += lbMenu_SelectionChanged;
            dgXml.CellEditEnded += dgXml_CellEditEnded;
            dgXml.KeyUp += dgXml_KeyUp;
        }

        private void dgXml_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    break;
                case Key.Left:
                    break;
                case Key.Up:
                    break;
                case Key.Down:
                    break;

                default:
                    {
                        var itemsource = (SortableCollectionView) dgXml.ItemsSource;
                        var dg = (DataGrid) sender;
                        int currentRow = itemsource.CurrentPosition;
                        var currentColumn = (string) dg.CurrentColumn.Header;
                        
                        XmlDataCollection[currentRow][currentColumn] = e.Key;

                        GetTile(currentRow, int.Parse(currentColumn)).Update();
                        break;
                    }
            }
        }

        private static void dgXml_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
        {
            var dg = (DataGrid) sender;
            var row = (Row) dg.SelectedItem;

            XmlDataCollection[e.Row.GetIndex()][e.Column.Header.ToString()] = row[e.Column.Header.ToString()].ToString();

            GetTile(e.Row.GetIndex(), int.Parse(e.Column.Header.ToString())).Update();
        }

        private void lbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lbMenu.SelectedIndex;
            CurrentCommand = (from command in Command.Commands
                              where command.Mode == CurrentMode
                              select command).ElementAtOrDefault(index);
        }
        
        private void lbMenu_Loaded(object sender, RoutedEventArgs e)
        {
            ParentListBox.ItemsSource = Command.Commands.Where(x => x.Mode == CurrentMode).Select(x => x.Name).ToList();

            ParentListBox.SelectedIndex = 0;
        }

        private void cbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentMode != cbMenu.SelectedIndex)
            {
                CurrentMode = cbMenu.SelectedIndex;
                ParentListBox.ItemsSource =
                    Command.Commands.Where(x => x.Mode == CurrentMode).Select(x => x.Name).ToList();
                CurrentCommand = Command.Commands.FirstOrDefault(x => x.Mode == CurrentMode && x.Letter == "");

                DataGridXmlUpdate();
                InitializeTiles();
            }
        }

        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (FocusManager.GetFocusedElement() != this)
                //Focus();

                if (CurrentMode == 1)
                {
                    switch (e.Key)
                    {
                        case Key.C:
                            CurrentMode = 2;
                            break;
                        case Key.T:
                            CurrentMode = 3;
                            break;
                        case Key.M:
                            CurrentMode = 4;
                            break;
                    }
                }

            if (e.Key == Key.Space && CurrentMode > 1)
                CurrentMode = 1;

            Command getCommand = (from command in Command.Commands
                                  where command.Mode == CurrentMode && command.Hotkey == e.Key
                                  select command).FirstOrDefault();
            if (getCommand != null)
            {
                CurrentCommand = getCommand;
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var import = new ImportExport();
            import.Closed += ImportExport_Closed;

            import.Title = "Import";
            rectFrame.Visibility = Visibility.Visible;

            import.Show();
        }

        private void ImportExport_Closed(object sender, EventArgs e)
        {
            var dlg = (ImportExport) sender;
            bool? result = dlg.DialogResult;

            if (dlg.tbMain.IsReadOnly != true)
            {
                if (result.HasValue && result.Value)
                {
                    ImportCSV(dlg.Import);
                }
            }
            rectFrame.Visibility = Visibility.Collapsed;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            var export = new ImportExport();
            export.Closed += ImportExport_Closed;

            export.Title = "Export";

            export.tbMain.IsReadOnly = true;
            export.tbMain.Text = new XmlFactory().ConvertXmlToCSV(CurrentMode, XmlDataCollection);

            rectFrame.Visibility = Visibility.Visible;

            export.Show();
        }

        private void btnChangeNumber_Click(object sender, RoutedEventArgs e)
        {
            if ((int) numColumns.Value != Columns || (int) numRows.Value != Rows)
            {
                int columnDeviation = (int) numColumns.Value - Columns;
                int rowDeviation = (int) numRows.Value - Rows;

                var xmlFact = new XmlFactory();

                XmlDocumentData = xmlFact.GridToXML(columnDeviation, rowDeviation, (int) numColumns.Value);
                XmlDataCollection = xmlFact.ConvertXmlToSortableCollectionView(XmlDocumentData);

                Columns = (int) numColumns.Value;
                Rows = (int) numRows.Value;

                DataGridXmlUpdate();

                InitializeTiles();

                dgXml.UpdateLayout();
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            numRows.Value = 20;
            numColumns.Value = 20;
            Columns = 20;
            Rows = 20;

            CurrentCommand = Command.Commands[1];

            // Creates Xml.
            _designationXmlData = new XmlFactory().PopulateXmlDataGrid(Rows, Columns, "data", Command.Commands[0].Letter);
            _buildXmlData = new XmlFactory().PopulateXmlDataGrid(Rows, Columns, "data", Command.Commands[62].Letter);

            // Sends stored Xml to be parsed and sorted into collection
            _designationData = new XmlFactory().ConvertXmlToSortableCollectionView(_designationXmlData);
            _buildData = new XmlFactory().ConvertXmlToSortableCollectionView(_buildXmlData);

            _designationTiles = new Data();
            _buildTiles = new Data();

            DataGridXmlUpdate();

            InitializeTiles();
        }

        private static void canvasMain_MouseEnter(object sender, MouseEventArgs e)
        {
            MouseDown = false;
        }

        private static void canvasMain_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseDown = false;
        }

        private static void canvasMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseDown = false;
        }

        private static void canvasMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseDown = true;
        }

        private void cbTileset_Loaded(object sender, RoutedEventArgs e)
        {
            var cbItem = (ComboBoxItem)cbTileset.SelectedValue;
            Tileset = TilesetPath + @"/" + cbItem.Content + @"/";
        }

        private void cbTileset_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentTileset = Tileset;
            var cb = (ComboBox)sender;
            var cbi = (ComboBoxItem)cb.SelectedValue;

            switch ((string)cbi.Content)
            {
                case "phoebus":
                    if (currentTileset != TilesetPath + @"/phoebus/")
                    {
                        Tileset = TilesetPath + @"/phoebus/";
                        InitializeTiles();
                    }
                    break;
                case "default":
                    if (currentTileset != TilesetPath + @"/default/")
                    {
                        Tileset = TilesetPath + @"/default/";
                        InitializeTiles();
                    }
                    break;
            }
        }

        #endregion

        #region Methods

        private static Tile GetTile(int row, int column)
        {
            return (from tile in Tiles
                    where tile.RowId == row && tile.ColumnId == column
                    select tile).FirstOrDefault();
        }

        public List<string> ColumnNames(XDocument xDocument)
        {
            return xDocument.Descendants("column")
                .Attributes("name")
                .Select(a => a.Value)
                .ToList();
        }

/*
        /// <summary>
        /// Sets rows/columns to screensize.  Retain this code perminately.
        /// </summary>
        private void setCanvasDimensionsFluid()
        {
            Columns = (int) ParentCanvas.RenderSize.Width/TileWidth;
            Rows = (int) ParentCanvas.RenderSize.Height/TileHeight;
        }
*/

        /// <summary>
        /// Sets initial data.
        /// </summary>
        public void InitializeTiles()
        {
            // Clear canvas and tile datastore.
            ParentCanvas.Children.Clear();
            Tiles.Clear();

            Tiles = new Data();

            // 
            var tiles = XmlDataCollection;
            var index = 0;

            for (var rowId = 0; rowId < Rows; rowId++)
            {
                for (var columnId = 0; columnId < Columns; columnId++)
                {
                    var tile = new Tile
                                   {
                                       Name = "R" + rowId + "C" + columnId,
                                       Command = new Command().GetCommandByLetter((string) tiles[rowId][columnId.ToString()], CurrentMode),
                                       ColumnId = columnId,
                                       RowId = rowId,
                                       X = columnId*TileWidth,
                                       Y = rowId*TileHeight,
                                       Index = index
                                   };

                    Tiles.Add(tile);

                    index++;
                }
            }
            // Set Column dimentions to resulted columns/rows
            ParentCanvas.Width = Columns*TileWidth;
            ParentCanvas.Height = Rows*TileHeight;
        }
        
        public void DataGridXmlUpdate()
        {
            // clear the grid
            ParentDataGrid.ItemsSource = null;
            ParentDataGrid.Columns.Clear();

            // find the columns
            List<string> columnNames = ColumnNames(XmlDocumentData);

            // add them to the grid
            foreach (string columnName in columnNames)
            {
                ParentDataGrid.Columns.Add(new DataGridTextColumn
                                               {
                                                   CanUserSort = true,
                                                   Header = columnName,
                                                   SortMemberPath = columnName,
                                                   IsReadOnly = false,
                                                   Binding = new Binding("Data")
                                                                 {
                                                                     Converter = _rowIndexConverter,
                                                                     ConverterParameter = columnName
                                                                 }
                                               });
            }


            ParentDataGrid.ItemsSource = XmlDataCollection;
        }

        /// <summary>
        /// Imports CSV data to data store
        /// </summary>
        private void ImportCSV(string csvInput)
        {
            int rowId = 0;
            int columns = 0;
            var delimiters = new[] {'\r', '\n'};
            string[] rows = csvInput.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var xmlDoc = new XDocument();

            var xmlroot = new XElement("root");
            var xmlcolumns = new XElement("columns");
            var xmlrows = new XElement("rows");

            foreach (string row in rows)
            {
                if (row.Contains(@"#dig") || row.Contains(@"#build"))
                {
                    if (row.Contains(@"#dig"))
                    {
                        CurrentMode = 0;
                        _designationTiles.Clear();
                        _designationTiles = new Data();
                    }
                    else
                    {
                        CurrentMode = 1;
                        _buildTiles.Clear();
                        _buildTiles = new Data();
                    }
                }
                else // Default
                {
                    var xmlrow = new XElement("row", new XAttribute("index", rowId));
                    int n = 0;
                    foreach (string cell in row.Split(','))
                    {
                        if (cell != @"#")
                        {
                            xmlrow.Add(new XElement("cell", cell));
                            n++;
                        }
                    }

                    xmlrows.Add(xmlrow);

                    rowId++;

                    if (columns < n)
                        columns = n;
                }
            }

            for (int i = 0; i < columns; i++)
            {
                xmlcolumns.Add(new XElement("column", new XAttribute("name", i)));
            }

            xmlroot.Add(xmlrows);
            xmlroot.Add(xmlcolumns);

            xmlDoc.Add(xmlroot);

            XmlDataCollection = new XmlFactory().ConvertXmlToSortableCollectionView(xmlDoc);
            XmlDocumentData = xmlDoc;

            Rows = rowId;
            Columns = columns;

            DataGridXmlUpdate();

            InitializeTiles();
        }

        #endregion

       
    }
}