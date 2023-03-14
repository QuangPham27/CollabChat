using CollabChatClient.MVVM.Core;
using CollabChatClient.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.MVVM.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<ChatRoomModel> ChatRooms { get; set; }
        public ObservableCollection<InboxModel> Inboxes { get; set; }
        public ObservableCollection<FriendshipModel> Friendships { get; set; }
        public ObservableCollection<UserModel> BlockedUsers { get; set; }
        public ObservableCollection<UserModel> OnlineFriends { get; set; }
        public ObservableCollection<UserModel> AllFriends { get; set; }

        public RelayCommand getChatRoomListCommand;
        public RelayCommand getInboxListCommand;
        public int UserId { get; set; }
        public HomeViewModel() 
        {
           
        }
    }
}
