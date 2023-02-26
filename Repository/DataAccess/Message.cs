using System;
using System.Collections.Generic;

namespace Database.DataAccess
{
    public partial class Message
    {
        public Message()
        {
            Files = new HashSet<File>();
            ChatRooms = new HashSet<ChatRoom>();
            Inboxes = new HashSet<Inbox>();
        }

        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual User Sender { get; set; }
        public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<ChatRoom> ChatRooms { get; set; }
        public virtual ICollection<Inbox> Inboxes { get; set; }
    }
}
