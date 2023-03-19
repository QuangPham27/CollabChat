// See https://aka.ms/new-console-template for more information
using Database.DataAccess;
using Database.Management;

Console.WriteLine("Hello, World!");
BlockedManagement x = new BlockedManagement();
List<BlockedUser> a = (List<BlockedUser>)x.blockedUserList(1);
foreach (BlockedUser u in a)
{
    Console.WriteLine(u.BlockedUserNavigation.Username);
}

//foreach (Inbox inbox in x)
//{
//    Console.WriteLine("Inbox ID: "+inbox.InboxId);
//    Console.WriteLine("User 1 " + inbox.User1Id + " " + inbox.User1.Username);
//    Console.WriteLine("User 2 " + inbox.User2Id + " " + inbox.User2.Username);
//    foreach (Message message in inbox.Messages)
//    {
//        Console.WriteLine("Message: " + message.Content);
//    }
//}


