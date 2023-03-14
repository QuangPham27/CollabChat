using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.MVVM.Model
{
    public class FriendshipModel
    {
        public int FriendshipId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverID { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AcceptedDate { get; set; }
    }
}
