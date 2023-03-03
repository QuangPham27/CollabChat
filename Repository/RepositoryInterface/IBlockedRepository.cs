using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.RepositoryInterface
{
    public interface IBlockedRepository
    {
        void addBlocked(int user_id, int blocked_user_id);
        void removeBlocked(int user_id, int blocked_user_id);
    }
}
