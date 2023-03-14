using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatServer.Model
{
    public class FriendShipModel
    {
        public int FriendshipId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverID { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AcceptedDate { get; set; }
    }
}
