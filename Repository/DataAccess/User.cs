using System;
using System.Collections.Generic;

namespace Database.DataAccess
{
    public partial class User
    {
        public User()
        {
            BlockedUserBlockedUserNavigations = new HashSet<BlockedUser>();
            BlockedUserUsers = new HashSet<BlockedUser>();
            ChatRooms = new HashSet<ChatRoom>();
            FriendshipReceivers = new HashSet<Friendship>();
            FriendshipSenders = new HashSet<Friendship>();
            InboxUser1s = new HashSet<Inbox>();
            InboxUser2s = new HashSet<Inbox>();
            Messages = new HashSet<Message>();
            ChatRoomsNavigation = new HashSet<ChatRoom>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Username { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<BlockedUser> BlockedUserBlockedUserNavigations { get; set; }
        public virtual ICollection<BlockedUser> BlockedUserUsers { get; set; }
        public virtual ICollection<ChatRoom> ChatRooms { get; set; }
        public virtual ICollection<Friendship> FriendshipReceivers { get; set; }
        public virtual ICollection<Friendship> FriendshipSenders { get; set; }
        public virtual ICollection<Inbox> InboxUser1s { get; set; }
        public virtual ICollection<Inbox> InboxUser2s { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<ChatRoom> ChatRoomsNavigation { get; set; }
    }
}
