using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.MVVM.Model
{
    public class ChatRoomModel
    {
        public int ChatRoomId { get; set; }
        public int CreatorId { get; set; }
        public string ChatRoomName { get; set; }
        public string ChatRoomPictureUrl { get; set; }
        public List<UserModel> ChatRoomUsers { get; set; }
        public List<MessageModel> ChatRoomMessages { get; set; }
    }
}
