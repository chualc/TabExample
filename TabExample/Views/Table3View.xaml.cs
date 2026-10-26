using System.Windows;
using System.Windows.Controls;

// TODO: Step 3: Refer to Table3View.xaml.
// TODO: Step 4: Implement the DataGrid_AutoGeneratingColumn event handler to center-align the text in the DataGrid columns.
namespace TabExample.Views
{
    /// <summary>
    /// Interaction logic for Table3View.xaml
    /// </summary>
    public partial class Table3View : UserControl
    {
        public Table3View()
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
