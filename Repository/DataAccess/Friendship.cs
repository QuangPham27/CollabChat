using System;
using System.Collections.Generic;

namespace Database.DataAccess
{
    public partial class Friendship
    {
        public int FriendshipId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AcceptedDate { get; set; }

        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
    }
}
