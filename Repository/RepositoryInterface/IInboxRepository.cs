using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.RepositoryInterface
{
    public interface IInboxRepository
    {
        void AddInbox(int user_id1, int user_id2);
        IEnumerable<Inbox> GetInboxes(int user_id);
        void GetInbox(int user_id1, int user_id2);
    }
}
