using Dictionary.Models;
using Dictionary.Repository;
using System.Linq;

namespace Dictionary.Services
{
    public class AuthenticationService
    {
        private UserRepository userRepository;

        public AuthenticationService()
        {
            userRepository = new UserRepository();
        }

        public bool Login(string username, string password)
        {
            var users = userRepository.GetUsers();

            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user != null;
        }

        public bool Register(string username, string password)
        {
            var users = userRepository.GetUsers();

            if (users.Any(u => u.Username == username))
            {
                throw new UserExistsException();
            }

            var newUser = new User { Username = username, Password = password };
            userRepository.AddUser(newUser);
            return true;

        }
    }
}
