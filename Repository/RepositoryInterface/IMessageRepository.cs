using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.RepositoryInterface
{
    public interface IMessageRepository
    {
        Message GetMessage(string content);
        void AddInboxMessage(Message message, int inbox_id);
        void AddChatRoomMessage(Message message, int chat_room_id);
    }
}
