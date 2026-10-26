// TODO: Step 2: Add a new ViewModel class for the third table (Table3ViewModel) that implements the INotifyPropertyChanged interface and contains an ObservableCollection<Table3Model> property to hold the data for the table. Implement a command to handle double-click events on the rows of the table and show a dialog with the details of the selected row.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TabExample.Models;
using TabExample.Services;

namespace TabExample.ViewModels
{
    public class Table3ViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;

        public string TabTitle => "Table3";

        public ObservableCollection<Table3Model> Items { get; }

        public RelayCommand<Table3Model> RowDoubleClickCommand
        {
            get;
        }

        public Table3ViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Items = new ObservableCollection<Table3Model>
            {
                new Table3Model
                {
                    Id = 201,
                    Column1 = "P",
                    Column2 = "Data P"
                },
                new Table3Model
                {
                    Id = 202,
                    Column1 = "Q",
                    Column2 = "Data Q"
                },
                new Table3Model
                {
                    Id = 203,
                    Column1 = "R",
                    Column2 = "Data R"
                }
            };

            RowDoubleClickCommand =
                new RelayCommand<Table3Model>(ShowDetails);
        }

        private void ShowDetails(Table3Model item)
        {
            if (item == null)
                return;

            string message =
                "ID: " + item.Id + "\n" +
                "Column1: " + item.Column1 + "\n" +
                "Column2: " + item.Column2;

            _dialogService.ShowDetails(
                "Table3 Details", message);
        }
    }
}
