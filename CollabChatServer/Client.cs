using CollabChatServer.Model;
using CollabChatServer.Net.IO;
using Database.DataAccess;
using Database.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatServer
{
    class Client
    {
        public string Username { get; set; }
        public TcpClient ClientSocket { get; set; }
        PacketReader _packetReader;
        public Client(TcpClient client) 
        {
            ClientSocket = client;
            _packetReader = new PacketReader(ClientSocket.GetStream());

            Task.Run(() => Process());
        }
        void Process()
        {
            while (true)
            {
                try
                {
                    var opcode = _packetReader.ReadByte();
                    switch (opcode)
                    {
                        case Constants.loginOpCode:
                            byte loginResponseOpcode;
                            UserModel login = _packetReader.ReadObject<UserModel>();
                            UserManagement userManagement = new UserManagement();
                            User user = userManagement.UserLogin(login.username, login.password);
                            if (user == null) loginResponseOpcode = Constants.loginFailureOpCode;
                            else loginResponseOpcode = Constants.loginSuccessOpCode;
                            var loginResponse = new PacketBuilder();
                            loginResponse.WriteOpCode(loginResponseOpcode);
                            ClientSocket.Client.Send(loginResponse.GetPacketBytes());
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception) 
                {
                    ClientSocket.Close();
                    break;
                }
            }
        }
    }
}
