
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TabExample.Models;
using TabExample.ViewModels;

namespace TabExample.Views
{
    public partial class Table1View : UserControl
    {
        public Table1View()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(
            object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            var textColumn = e.Column as DataGridTextColumn;

            if (textColumn == null)
                return;

            var textStyle = new Style(typeof(TextBlock));

            textStyle.Setters.Add(
                new Setter(
                    TextBlock.TextAlignmentProperty,
                    TextAlignment.Center));

            textStyle.Setters.Add(
                new Setter(
                    FrameworkElement.VerticalAlignmentProperty,
                    VerticalAlignment.Center));

            textColumn.ElementStyle = textStyle;
        }

    }
}