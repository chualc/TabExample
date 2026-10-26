
using System.Windows;
using TabExample.Services;
using TabExample.ViewModels;

namespace TabExample.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IDialogService dialogService = new DialogService();

            DataContext = new MainViewModel(dialogService);
        }
    }
}
