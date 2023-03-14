using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.MVVM.Model
{
    public class InboxModel
    {
        public int InboxId { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public List<MessageModel> InboxMessages { get; set; }
    }
}
