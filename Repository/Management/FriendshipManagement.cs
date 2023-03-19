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
    public class FriendshipManagement : BaseManagement, IFriendshipRepository
    {
        public void AddFriendship(Friendship friendship)
        {
            databaseContext.Friendships.Add(friendship);
            databaseContext.SaveChanges();
        }

        public IEnumerable<User> GetAllFriends(int user_id)
        {
            List<User> friends = null;
            var acceptedFriendships = databaseContext.Friendships
                .Where(f => f.IsAccepted && (f.SenderId == user_id || f.ReceiverId == user_id))
                .Select(f => new { SenderId = f.SenderId, ReceiverId = f.ReceiverId })
                .ToList();

            var friendIds = acceptedFriendships
                .SelectMany(f => new[] { f.SenderId, f.ReceiverId })
                .Where(id => id != user_id)
                .Distinct()
                .ToList();

            friends = databaseContext.Users
                .Where(u => friendIds.Contains(u.UserId))
                .ToList();
            return friends;
        }


        public List<Friendship> GetPendingFriendships(int user_id)
        {
            List<Friendship> pendingFriendship = null;
            pendingFriendship = databaseContext.Friendships.Include(o => o.Sender).Where(o => o.ReceiverId== user_id).ToList();
            return pendingFriendship;
        }

        public void RemoveFriendship(int user_id1, int user_id2)
        {
            var friendship = databaseContext.Friendships.FirstOrDefault(o => 
            (o.SenderId == user_id1 && o.ReceiverId == user_id2) || (o.SenderId == user_id2 && o.ReceiverId == user_id1));
            if (friendship != null)
            {
                databaseContext.Friendships.Remove(friendship);
            }
            databaseContext.SaveChanges();
        }
    }
}
