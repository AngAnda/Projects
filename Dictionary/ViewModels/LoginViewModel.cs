using Dicitionary.Views;
using Dictionary.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Dicitionary.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        private readonly AuthenticationService _authenticationService;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
            _authenticationService = new AuthenticationService();
        }

        private bool CanExecuteLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin(object parameter)
        {
            if (_authenticationService.Login(Username, Password))
            {
                Password = string.Empty;
                Username = string.Empty;
                ((MainWindow)Application.Current.MainWindow).MainNavigationFrame.Navigate(new Administration());
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
