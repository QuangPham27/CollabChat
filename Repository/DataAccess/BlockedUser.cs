using System;
using System.Collections.Generic;

namespace Database.DataAccess
{
    public partial class BlockedUser
    {
        public int UserId { get; set; }
        public int BlockedUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User BlockedUserNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
