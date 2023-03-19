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
    public class MessageManagement : BaseManagement, IMessageRepository
    {
        public void AddChatRoomMessage(Message message, int chat_room_id)
        {
            var chatRoom = databaseContext.ChatRooms.Include(o => o.Messages).FirstOrDefault(o => o.ChatRoomId == chat_room_id);
            if (chatRoom != null)
            {
                databaseContext.Messages.Add(message);
                chatRoom.Messages.Add(message);
                databaseContext.SaveChanges();
            }
        }

        public void AddInboxMessage(Message message, int inbox_id)
        {
            var inbox = databaseContext.Inboxes.Include(o => o.Messages).FirstOrDefault(o => o.InboxId == inbox_id);
            if (inbox != null)
            {
                databaseContext.Messages.Add(message);
                inbox.Messages.Add(message);
                databaseContext.SaveChanges();
            }
        }

        public Message GetMessage(string content)
        {
            Message message = null;
            message = databaseContext.Messages.Include(o => o.SenderId).FirstOrDefault(o => o.Content == content);
            return message;
        }
    }
}
