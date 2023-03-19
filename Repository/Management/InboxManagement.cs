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
    public class InboxManagement : BaseManagement, IInboxRepository
    {
        public void AddInbox(int user_id1, int user_id2)
        {
            Inbox inbox = new Inbox{
                User1Id = user_id1,
                User2Id = user_id2
            };
            databaseContext.Inboxes.Add(inbox);
            databaseContext.SaveChanges();
        }

        public Inbox GetInbox(int user_id1, int user_id2)
        {
            Inbox inbox = databaseContext.Inboxes.Include(o => o.Messages).FirstOrDefault(
                o => (o.User1Id == user_id1 && o.User2Id == user_id2) || (o.User1Id == user_id2 && o.User2Id == user_id1));
            return inbox;
        }

        public IEnumerable<Inbox> GetInboxes(int user_id)
        {
            List<Inbox> inboxes = null;
            inboxes = databaseContext.Inboxes.Include(o => o.Messages).Include(o => o.User1).Include(o => o.User2)
                .Where(o => o.User1Id == user_id || o.User2Id == user_id).ToList();
            //swap for easier use later
            foreach(var inbox in inboxes)
            {
                if (inbox.User2Id == user_id)
                {
                    var temp = inbox.User1; var temp2 = inbox.User1Id;
                    inbox.User1 = inbox.User2; inbox.User1Id = inbox.User2Id;
                    inbox.User2 = temp; inbox.User2Id = temp2;
                }
            }
            return inboxes;
        }
    }
}
