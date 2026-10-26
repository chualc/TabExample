using System.Windows;

namespace TabExample.Views
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow()
        {
            InitializeComponent();
        }

        public void SetMessage(string message)
        {
            MessageText.Text = message;
        }
    }
}
