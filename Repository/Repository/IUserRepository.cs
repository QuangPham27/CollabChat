using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetChatRoomUsers(int chat_room_id);
        User GetUser(int user_id);
        void AddUser(User user);
        void DeleteUser(int user_id);
        void UpdateUser(User user, int userId);
    }
}
