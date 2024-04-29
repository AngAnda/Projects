using Dicitionary.ViewModels;
using Dictionary.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Dictionary.ViewModels
{
    public class ManageCredentialsViewModel : BaseViewModel
    {
        private ManageUsersService _userService;

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        private ObservableCollection<string> _usernames;
        public ObservableCollection<string> Usernames
        {
            get { return _usernames; }
            set
            {
                _usernames = value;
                NotifyPropertyChanged(nameof(Usernames));
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand LoadUsernamesCommand { get; }

        public ManageCredentialsViewModel()
        {
            _userService = new ManageUsersService();

            AddUserCommand = new RelayCommand(ExecuteAddUser, CanExecuteAddUser);
            LoadUsernamesCommand = new RelayCommand(ExecuteLoadUsernames);

            Usernames = _userService.GetAllUsernames();
        }

        private void ExecuteAddUser(object parameter)
        {
            bool added = _userService.AddUser(Username, Password);
            if (added)
            {
                LoadUsernames();
            }
            else
            {
                MessageBox.Show("Username already exists");
            }

        }

        private bool CanExecuteAddUser(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLoadUsernames(object parameter)
        {
            LoadUsernames();
        }

        private void LoadUsernames()
        {
            var usernames = _userService.GetAllUsernames();
            Usernames.Clear();
            foreach (var username in usernames)
            {
                Usernames.Add(username);
            }
        }

    }
}

