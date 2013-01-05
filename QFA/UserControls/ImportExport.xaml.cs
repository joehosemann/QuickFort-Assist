using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using QFA.Model;
using QFA.Utilities;

namespace QFA.UserControls
{
    public partial class ImportExport : ChildWindow
    {
        public string Export { get; set; }
        public string Import { get; set; }

        public ImportExport()
        {
            InitializeComponent();

            if (Export != null)
            {
                tbMain.IsReadOnly = true;
                tbMain.Text = Export;
            }
            else
            {
                tbMain.IsReadOnly = false;
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (!tbMain.IsReadOnly)
                Import = tbMain.Text;

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }




    }
}

