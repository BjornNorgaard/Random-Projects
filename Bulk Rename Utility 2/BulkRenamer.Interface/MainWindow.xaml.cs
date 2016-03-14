using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bulk_Rename_Utility_2;

namespace BulkRenamer.Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        System.Windows.Forms.DialogResult result;

        Brutto _brutto = new Brutto();

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            result = dialog.ShowDialog();
            _brutto.Folder = dialog.SelectedPath;
        }

        private void StringContainedInFileName_OnGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= StringContainedInFileName_OnGotFocus;
        }

        private void TextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_OnGotFocus;
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            //_brutto.Folder = result.ToString();
            _brutto.StringContainedInTarget = StringContainedInFileName.Text;
            _brutto.NewNameForFile = NewNameTextBox.Text;

            _brutto.Rename();
        }
    }
}
