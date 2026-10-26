using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TabExample.Services;


namespace TabExample.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private int _selectedTabIndex = 0; // Default to the first tab

        public ObservableCollection<object> Tabs { get; }

        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set => SetProperty(ref _selectedTabIndex, value);
        }

        public MainViewModel(IDialogService dialogService)
        {
            Tabs = new ObservableCollection<object>
            {
                new Table1ViewModel(dialogService),
                new Table2ViewModel(dialogService),
                new Table3ViewModel(dialogService) // TODO: Step 5: Add the third table's ViewModel to the Tabs collection
                // TODO: Step 6 and 7: Refer to MainWindow.xaml to add a new TabItem for the third table in the TabControl.
            };
        }
    }
}