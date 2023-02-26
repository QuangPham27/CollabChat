using System;
using System.Collections.Generic;

namespace Database.DataAccess
{
    public partial class Inbox
    {
        public Inbox()
        {
            Messages = new HashSet<Message>();
        }

        public int InboxId { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
