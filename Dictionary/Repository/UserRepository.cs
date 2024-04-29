using Dictionary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Dictionary.Repository
{
    public class UserRepository
    {
        public ObservableCollection<User> users = new ObservableCollection<User>();

        private string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources", "users.json");

        public UserRepository()
        {
            users = GetUsers() ?? new ObservableCollection<User>();
        }

        public ObservableCollection<User> GetUsers()
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }
            try
            {
                string json = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
                return (list != null) ? list : new ObservableCollection<User>();
            }
            catch (Exception)
            {
                return new ObservableCollection<User>();
            }
        }

        public void AddUser(User user)
        {
            if (users.Any(u => u.Username == user.Username))
            {
                throw new UserExistsException();
            }
            users.Add(user);
            SaveUsers();
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
            SaveUsers();
        }

        public void UpdateUser(User user, int index)
        {
            users[index] = user;
            SaveUsers();
        }

        public void SaveUsers()
        {
            try
            {
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
