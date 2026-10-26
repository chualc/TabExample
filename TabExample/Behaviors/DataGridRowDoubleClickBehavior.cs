using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TabExample.Behaviors
{
    public static class DataGridRowDoubleClickBehavior
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(DataGridRowDoubleClickBehavior),
                new PropertyMetadata(null, OnCommandChanged));

        public static void SetCommand(
            DependencyObject element, ICommand value)
        {
            element.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        private static void OnCommandChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            DataGrid grid = d as DataGrid;

            if (grid == null)
                return;

            if (e.OldValue != null)
                grid.MouseDoubleClick -= OnMouseDoubleClick;

            if (e.NewValue != null)
                grid.MouseDoubleClick += OnMouseDoubleClick;
        }

        private static void OnMouseDoubleClick(
            object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            if (grid == null)
                return;

            // Find the row that received the double-click.
            DependencyObject source =
                e.OriginalSource as DependencyObject;

            DataGridRow row =
                ItemsControl.ContainerFromElement(grid, source)
                as DataGridRow;

            // Ignore clicks on headers or empty space.
            if (row == null)
                return;

            ICommand command = GetCommand(grid);
            object item = row.Item;

            if (command != null && command.CanExecute(item))
            {
                command.Execute(item);
            }
        }
    }
}