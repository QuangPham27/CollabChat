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
    public class BlockedManagement : BaseManagement, IBlockedRepository
    {
        public void addBlocked(int user_id, int blocked_user_id)
        {
            databaseContext.BlockedUsers.Add(new BlockedUser
            {
                UserId = user_id,
                BlockedUserId = blocked_user_id,
                CreatedAt = DateTime.Now,
            });
            databaseContext.SaveChanges();
        }

        public List<BlockedUser> blockedUserList(int user_id)
        {
            List<BlockedUser> blockedUserList = null;
            blockedUserList = databaseContext.BlockedUsers.Include(o => o.BlockedUserNavigation).Where(o => o.UserId == user_id).ToList();
            return blockedUserList;
        }

        public void removeBlocked(int user_id, int blocked_user_id)
        {
            var blocked = databaseContext.BlockedUsers.FirstOrDefault(o => o.UserId == user_id && o.BlockedUserId == blocked_user_id);
            if (blocked != null)
            {
                databaseContext.BlockedUsers.Remove(blocked);
                databaseContext.SaveChanges();
            }
        }
    }
}
