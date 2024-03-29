﻿using CollabChatClient.MVVM.Model;
using CollabChatClient.MVVM.ViewModel;
using CollabChatClient.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient
{
    public class Server
    {
        private static Server instance = null;
        public event Action connectedEvent;
        TcpClient _client;
        public PacketReader packetReader;
        public Server()
        {
            _client = new TcpClient();
            //connect the client to server 
            //_client.Connect("127.0.0.1", 5000);
        }
        public static Server GetInstance()
        {
            if (instance == null)
            {
                instance = new Server();
            }
            return instance;
        }

        public void ConnectToServer(string username, string password, ref string message)
        {
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 5000);
            }
            message = "";
            packetReader = new PacketReader(_client.GetStream());

            //sending login packet to server to check the valid login
            var loginPacket = new PacketBuilder();
            loginPacket.WriteOpCode(Constants.loginOpCode);
            UserModel user = new UserModel
            {
                Username = username,
                Password = password
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
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 5000);
            }
            message = "";
            packetReader = new PacketReader(_client.GetStream());

            //sending login packet to server to check the valid login
            var registerpacket = new PacketBuilder();
            registerpacket.WriteOpCode(Constants.registerOpCode);
            UserModel user = new UserModel
            {
                Username = username,
                Password = password,
                Email = email
            };
            registerpacket.WriteObject(user);
            _client.Client.Send(registerpacket.GetPacketBytes());

            //wait for server response for login
            var result = packetReader.ReadByte();
            if (result == Constants.registerSuccessOpCode)
            {
                message = "Register Success";
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
                while (true)
                {
                    var opcode = packetReader.ReadByte();
                    switch (opcode)
                    {
                        default:
                            break;
                    }
                }
            });
        }


    }
}
