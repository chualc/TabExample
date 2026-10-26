using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using TabExample.Models;
using TabExample.Services;

namespace TabExample.ViewModels
{
    public class Table1ViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;

        public string TabTitle
        {
            get { return "Table1"; }
        }

        public ObservableCollection<Table1Model> Items { get; }

        public RelayCommand<Table1Model> RowDoubleClickCommand
        {
            get;
        }

        public Table1ViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Items = new ObservableCollection<Table1Model>
            {
                new Table1Model
                {
                    Id = 1,
                    Column1 = "A",
                    Column2 = "Data 1"
                },
                new Table1Model
                {
                    Id = 2,
                    Column1 = "B",
                    Column2 = "Data 2"
                },
                new Table1Model
                {
                    Id = 3,
                    Column1 = "C",
                    Column2 = "Data 3"
                }
            };

            RowDoubleClickCommand =
                new RelayCommand<Table1Model>(ShowDetails);
        }

        private void ShowDetails(Table1Model item)
        {
            if (item == null)
                return;

            string message =
                "ID: " + item.Id + "\n" +
                "Column1: " + item.Column1 + "\n" +
                "Column2: " + item.Column2;

            _dialogService.ShowDetails(
                "Table1 Details", message);
        }
    }
}