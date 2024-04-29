using Dicitionary.Views;
using System.Windows;

namespace Dicitionary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainNavigationFrame.Navigate(new OpeningPage());
        }
    }
}
