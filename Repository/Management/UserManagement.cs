using Database.DataAccess;
using Database.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
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
            List<User> users = null;
            var chat_room = databaseContext.ChatRooms.Include(c => c.Users).FirstOrDefault(c => c.ChatRoomId == chat_room_id);
            if (chat_room != null) users = chat_room.Users.ToList();
            return users;
        }

        public User GetUser(int user_id)
        {
            User user = databaseContext.Users.FirstOrDefault(u => u.UserId == user_id);
            return user;
        }

        public void AddUser(User user)
        {
            try
            {
                databaseContext.Users.Add(user);
                databaseContext.SaveChanges();
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

        public void UpdateUser(User updatedUser, int userId)
        {
            var user = databaseContext.Users.FirstOrDefault(o => o.UserId == userId);
            if (user != null)
            {
                user.Username = updatedUser.Username;
                user.PasswordHash = updatedUser.PasswordHash;
                user.ProfilePictureUrl = updatedUser.ProfilePictureUrl;
                user.Email = updatedUser.Email;
                user.AboutMe = updatedUser.AboutMe;
            }
            databaseContext.SaveChanges();
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


        public IEnumerable<User> GetBlockedUsers(int user_id)
        {
            List<User> blockedUsers = null;
            var temp = databaseContext.BlockedUsers.Join(
                    databaseContext.Users,
                    bu => bu.BlockedUserId,
                    u => u.UserId,
                    (bu, u) => new User
                    {
                        UserId = u.UserId,
                        Username = u.Username,
                        Email = u.Email,
                        PasswordHash = u.PasswordHash,
                        AboutMe = u.AboutMe,
                        ProfilePictureUrl = u.ProfilePictureUrl,
                        CreatedDate = u.CreatedDate
                    });
            blockedUsers = temp.ToList();
            return blockedUsers;
        }
    }
}
