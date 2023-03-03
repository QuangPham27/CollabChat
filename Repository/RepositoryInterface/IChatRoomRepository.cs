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
        void RemoveChatRoom(ChatRoom chatRoom);
        void UpdateChatRoom(ChatRoom chatRoom);
        void JoinChatRoom(int user_id, int chat_room_id);
    }
}
