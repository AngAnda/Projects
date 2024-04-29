using System.Windows;
using System.Windows.Controls;

namespace Dicitionary.Views
{
    public partial class OpeningPage : Page
    {

        public OpeningPage()
        {
            InitializeComponent();
        }

        private void GoToLogin(object sender, System.Windows.RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainNavigationFrame.Navigate(new Login());
        }

        private void GoToUserPage(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainNavigationFrame.Navigate(new UserPage());

        }

        private void GoToQuizPage(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainNavigationFrame.Navigate(new UserQuiz());
        }
    }
}
