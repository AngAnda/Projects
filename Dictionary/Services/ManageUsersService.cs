using Dictionary.Models;
using Dictionary.Repository;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dictionary.Services
{
    public class ManageUsersService
    {
        private UserRepository _userRepository;

        public ManageUsersService()
        {
            _userRepository = new UserRepository();
        }

        public bool AddUser(string username, string password)
        {
            var users = _userRepository.GetUsers();
            if (users.Any(u => u.Username == username))
            {
                return false;
            }

            User newUser = new User { Username = username, Password = password };
            _userRepository.AddUser(newUser);
            return true;
        }

        public ObservableCollection<string> GetAllUsernames()
        {
            var users = _userRepository.GetUsers();
            var usernames = new ObservableCollection<string>(users.Select(u => u.Username));
            return usernames;
        }
    }
}
