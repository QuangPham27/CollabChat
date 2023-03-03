using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.RepositoryInterface
{
    public interface IFriendshipRepository
    {
        void AddFriendship(Friendship friendship);
        Friendship GetFriendship(int user_id);
        IEnumerable<Friendship> GetAllFriends(int user_id);
        void RemoveFriendship(int user_id1, int user_id2);
    }
}
