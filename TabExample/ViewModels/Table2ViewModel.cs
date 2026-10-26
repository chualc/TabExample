using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using TabExample.Models;
using TabExample.Services;

namespace TabExample.ViewModels
{
    public class Table2ViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;

        public string TabTitle
        {
            get { return "Table2"; }
        }

        public ObservableCollection<Table2Model> Items { get; }

        public RelayCommand<Table2Model> RowDoubleClickCommand
        {
            get;
        }

        public Table2ViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Items = new ObservableCollection<Table2Model>
            {
                new Table2Model
                {
                    Id = 101,
                    Column1 = "X",
                    Column2 = "Data X"
                },
                new Table2Model
                {
                    Id = 102,
                    Column1 = "Y",
                    Column2 = "Data Y"
                },
                new Table2Model
                {
                    Id = 103,
                    Column1 = "Z",
                    Column2 = "Data Z"
                }
            };

            RowDoubleClickCommand =
                new RelayCommand<Table2Model>(ShowDetails);
        }

        private void ShowDetails(Table2Model item)
        {
            if (item == null)
                return;

            string message =
                "ID: " + item.Id + "\n" +
                "Column1: " + item.Column1 + "\n" +
                "Column2: " + item.Column2;

            _dialogService.ShowDetails(
                "Table2 Details", message);
        }
    }
}