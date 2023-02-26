using System;
using System.Collections.Generic;

namespace Database.DataAccess
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            Messages = new HashSet<Message>();
            Users = new HashSet<User>();
        }

        public int ChatRoomId { get; set; }
        public int CreatorId { get; set; }
        public string ChatRoomName { get; set; }
        public string ChatRoomPictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
