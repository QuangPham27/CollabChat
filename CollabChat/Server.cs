using CollabChatClient.MVVM.Model;
using CollabChatClient.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient
{
    class Server
    {
        public event Action connectedEvent;
        TcpClient _client;
        public PacketReader packetReader;
        public Server()
        {
            _client = new TcpClient();
        }

        public void ConnectToServer(string username, string password, ref string message)
        {
            message = "";
            if (!_client.Connected)
            {
                //connect the client to server 
                _client.Connect("127.0.0.1", 5000);
            }
                packetReader = new PacketReader(_client.GetStream());

                //sending login packet to server to check the valid login
                var loginPacket = new PacketBuilder();
                loginPacket.WriteOpCode(Constants.loginOpCode);
                UserModel user = new UserModel
                {
                    username = username,
                    password = password
                };
                loginPacket.WriteObject(user);
                _client.Client.Send(loginPacket.GetPacketBytes());

                //wait for server response for login
                var result = packetReader.ReadByte();
                if (result == Constants.loginSuccessOpCode)
                {
                    message = "Login Success";
                    //ReadPackets();
                }
                else
                {
                    message = "Login Failed";
                }
            
        }

        public void Register(string username, string password, string email, ref string message)
        {
            message = "";
            if (!_client.Connected)
            {
                //connect the client to server 
                _client.Connect("127.0.0.1", 5000);
            }
            packetReader = new PacketReader(_client.GetStream());

            //sending login packet to server to check the valid login
            var registerpacket = new PacketBuilder();
            registerpacket.WriteOpCode(Constants.registerOpCode);
            UserModel user = new UserModel
            {
                username = username,
                password = password,
                email = email
            };
            registerpacket.WriteObject(user);
            _client.Client.Send(registerpacket.GetPacketBytes());

            //wait for server response for login
            var result = packetReader.ReadByte();
            if (result == Constants.registerOpCode)
            {
                message = "Register Success";
                //ReadPackets();
            }
            else
            {
                message = "Register Failed";
            }

        }

        void ReadPackets() 
        {
            Task.Run(() =>
            {
                while(true)
                {
                    var opcode = packetReader.ReadByte();
                    switch(opcode)
                    {
                        default:
                            break;
                    }
                }
            });
        }


    }
}
