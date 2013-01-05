using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using QFA.Model;
using System.Text.RegularExpressions;

namespace QFA.Utilities
{
    public class XmlFactory
    {

        /// <summary>
        /// Converts the contents of the grid into XML
        /// </summary>
        public XDocument GridToXML(int columnDeviation, int rowDeviation, int newColumnAmt)
        {
            var xdoc = new XDocument();

            var data = (SortableCollectionView)MainPage.ParentDataGrid.ItemsSource;
            var firstRow = data[0];

            // create the columns from the first row
            var xml = new XElement("data");
            var columns = (new XElement("columns", firstRow.ColumnNames.Select(col => new XElement("column", new XAttribute("name", col)))));
            var rows = new XElement("rows");


            // Adjust XML based on deviation amounts.

            if (columnDeviation > 0)
            {
                for (int i = 0; i < columnDeviation; i++)
                {
                    var index = newColumnAmt - columnDeviation + i;
                    columns.Add(new XElement("column", new XAttribute("name", index)));

                    foreach (var row in data)
                    {
                        row[index.ToString()] = "";
                    }
                }
            }
            if (columnDeviation < 0)
            {
                for (int i = 0; i < 0 - columnDeviation; i++)
                {
                    columns.Descendants().Last().Remove();
                }
            }

            var n = 0;
            foreach (Row row in data)
            {
                var newrow = new XElement("row", new XAttribute("index", n), firstRow.ColumnNames.Select(col => new XElement("cell", row[col])));

                if (columnDeviation < 0)
                {
                    for (int i = 0; i < 0 - columnDeviation; i++)
                    {
                        newrow.Descendants().Last().Remove();
                    }
                }
                rows.Add(newrow);
                n++;
            }


            if (rowDeviation > 0)
            {
                for (int i = 0; i < rowDeviation; i++)
                {
                    var row = new XElement("row", new XAttribute("index", n));

                    // Create cells for each row.  The amount of cells should always be equal to the number of columns.
                    for (int j = 0; j < newColumnAmt; j++)
                    {
                        row.Add(new XElement("cell", ""));
                    }

                    rows.Add(row);
                    n++;
                }
            }
            if (rowDeviation < 0)
            {
                for (int i = 0; i < 0 - rowDeviation; i++)
                {
                    rows.Descendants("row").Last().Remove();
                }
            }

            xml.Add(columns);
            xml.Add(rows);

            xdoc.Add(xml);

            return xdoc;
        }




        public XDocument PopulateXmlDataGrid(int rowsAmt, int columnsAmt, string root, string cellValue)
        {
            var xmlDataGridData = new XDocument();

            var xml = new XElement(root);
            var columns = new XElement("columns");
            var rows = new XElement("rows");

            for (int i = 0; i < columnsAmt; i++)
            {
                columns.Add(new XElement("column", new XAttribute("name", i)));
            }

            for (int i = 0; i < rowsAmt; i++)
            {
                var row = new XElement("row", new XAttribute("index", i));

                // Create cells for each row.  The amount of cells should always be equal to the number of columns.
                for (int j = 0; j < columnsAmt; j++)
                {
                    row.Add(new XElement("cell", cellValue));
                }

                rows.Add(row);
            }

            xml.Add(columns);
            xml.Add(rows);

            xmlDataGridData.Add(xml);

            return xmlDataGridData;
        }

        private List<string> columnNames(XDocument xDocument)
        {
            return xDocument.Descendants("column")
                .Attributes("name")
                .Select(a => a.Value)
                .ToList();
        }

        public SortableCollectionView ConvertXmlToSortableCollectionView(XDocument xDocument)
        {
            var data = new SortableCollectionView();

            // add the rows
            IEnumerable<XElement> rows = xDocument.Descendants("row");
            foreach (XElement row in rows)
            {
                var rowData = new Row();
                int index = 0;
                IEnumerable<XElement> cells = row.Descendants("cell");
                foreach (XElement cell in cells)
                {
                    if (!cell.Value.Contains("#"))
                    {
                        //var a = columnNames(xDocument)[index];
                        rowData[columnNames(xDocument)[index]] = cell.Value;
                        index++;
                    }
                }
                data.Add(rowData);
                //rowData["0"] returns first cell of row.
            }
            // data[0]["0"] returns first row, first cell
            return data;
        }

        public string ConvertXmlToCSV(int mode, SortableCollectionView sortableCollectionView)
        {
            var maxlength = 0;
            var text = new StringBuilder();

            if (mode == 0)
                text.Append("#dig start(1;1)\r\n");
            else
                text.Append("#build start(1;1)\r\n");

            // Finds max length of strings.
            foreach (Row row in sortableCollectionView)
            {
                for (int i = 0; i < MainPage.Columns; i++)
                {
                    if ((string)row[i.ToString()] != string.Empty && i > maxlength)
                        maxlength = i+1;
                }
            }

            foreach (Row row in sortableCollectionView)
            {
                for (int i = 0; i < maxlength; i++)
                {
                    text.Append(row[i.ToString()] + ",");
                }
                text.Append("#\r\n");
            }

            return text.ToString();
        }

    }
}
