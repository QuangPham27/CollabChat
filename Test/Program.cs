// See https://aka.ms/new-console-template for more information
using Database.DataAccess;
using Database.Management;

Console.WriteLine("Hello, World!");
UserManagement u = new UserManagement();
//List<User> list = (List<User>)u.GetChatRoomUsers(1);
List<User> list = (List<User>)u.GetUsers();

foreach (User user in list)
{
    Console.WriteLine(user.UserId);
}

