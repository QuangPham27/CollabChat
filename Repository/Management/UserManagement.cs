using Database.DataAccess;
using Database.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Management
{
    public class UserManagement : BaseManagement, IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            List<User> users = null;
            try
            {
                users = databaseContext.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

        public IEnumerable<User> GetChatRoomUsers(int chat_room_id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            try
            {
                databaseContext.Users.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user, int userId)
        {
            throw new NotImplementedException();
        }

        public User UserLogin(string username, string password)
        {
            User user = null;
            try
            {
                user = databaseContext.Users.FirstOrDefault(o => o.Username == username && o.PasswordHash == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public User UserRegister(string email)
        {
            User user = null;
            user = databaseContext.Users.FirstOrDefault(o => o.Email == email);
            return user;
        }
    }
}
