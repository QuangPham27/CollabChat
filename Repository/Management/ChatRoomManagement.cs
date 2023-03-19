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
    public class ChatRoomManagement : BaseManagement, IChatRoomRepository
    {
        public void AddChatRoom(ChatRoom chatRoom)
        {
            databaseContext.ChatRooms.Add(chatRoom);
            databaseContext.SaveChanges();
        }

        public ChatRoom GetChatRoom(int chat_room_id)
        {
            ChatRoom chatRoom = databaseContext.ChatRooms.Include(cr => cr.Users).Include(m => m.Messages).FirstOrDefault(o => o.ChatRoomId == chat_room_id);
            return chatRoom;
        }

        public IEnumerable<ChatRoom> GetChatRooms(int user_id)
        {
            List<ChatRoom> chatRooms = null;
            var users = databaseContext.Users.Include(cr => cr.ChatRooms).FirstOrDefault(o => o.UserId == user_id);
            if (users != null) 
            {
                chatRooms = users.ChatRooms.ToList();
            }
            return chatRooms;
        }

        public void JoinChatRoom(int user_id, int chat_room_id)
        {
            var chatRoom = databaseContext.ChatRooms.FirstOrDefault(o => o.ChatRoomId == chat_room_id);
            var user = databaseContext.Users.FirstOrDefault(o => o.UserId == user_id);
            chatRoom.Users.Add(user);
            databaseContext.SaveChanges();
        }

        public void RemoveChatRoom(int chat_room_id)
        {
            var chatRoom = databaseContext.ChatRooms.Include(c => c.Users).FirstOrDefault(o => o.ChatRoomId == chat_room_id);
            if (chatRoom != null)
            {
                foreach (var user in chatRoom.Users)
                {
                    chatRoom.Users.Remove(user);
                }
                databaseContext.ChatRooms.Remove(chatRoom);
                databaseContext.SaveChanges();
            }
        }

        public void UpdateChatRoom(int chat_room_id, ChatRoom updatedChatRoom)
        {
            var chatRoom = databaseContext.ChatRooms.Include(c => c.Users).FirstOrDefault(o => o.ChatRoomId == chat_room_id);
            if (chatRoom != null)
            {
                chatRoom.ChatRoomName = updatedChatRoom.ChatRoomName;
                chatRoom.ChatRoomPictureUrl = updatedChatRoom.ChatRoomPictureUrl;
            }
            databaseContext.SaveChanges();
        }
    }
}
