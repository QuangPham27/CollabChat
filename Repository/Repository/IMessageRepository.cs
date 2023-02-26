using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetInboxMessages(int inbox_id);
        IEnumerable<Message> GetChatRoomMessages(int chat_room_id);
        Message GetMessage(string content);
        void AddInboxMessage(Message message, int inbox_id);
        void AddChatRoomMessage(Message message, int chat_room_id);
    }
}
