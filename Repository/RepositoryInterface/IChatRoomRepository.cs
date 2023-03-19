using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.RepositoryInterface
{
    public interface IChatRoomRepository
    {
        IEnumerable<ChatRoom> GetChatRooms(int user_id);
        void AddChatRoom(ChatRoom chatRoom);
        void RemoveChatRoom(int chat_room_id);
        void UpdateChatRoom(int chat_room_id, ChatRoom updatedChatRoom);
        void JoinChatRoom(int user_id, int chat_room_id);
        ChatRoom GetChatRoom(int chat_room_id);
    }
}
