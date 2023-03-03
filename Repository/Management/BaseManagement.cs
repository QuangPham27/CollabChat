using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Management
{
    public class BaseManagement
    {
        private static BaseManagement instance = null;
        private static readonly object instanceLock = new object();
        public CollabChatDatabaseContext databaseContext = new CollabChatDatabaseContext(); 
        public static BaseManagement Instance
        {
            get 
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BaseManagement();
                    }
                    return instance;
                }
            }
        }
    }
}
