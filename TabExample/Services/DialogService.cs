using System.Windows;
using TabExample.Views;

namespace TabExample.Services
{
    public class DialogService : IDialogService
    {
        public void ShowDetails(string title, string message)
        {
            var window = new DetailsWindow
            {
                Title = title,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            window.SetMessage(message);
            window.ShowDialog();
        }
    }
}
