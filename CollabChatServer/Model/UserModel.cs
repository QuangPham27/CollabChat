using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatServer.Model
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { set; get; }
        public string AboutMe { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
