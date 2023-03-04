using CollabChatServer.Model;
using CollabChatServer.Net.IO;
using Database.DataAccess;
using Database.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        UserManagement userManagement = new UserManagement();
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
                            throw new Exception("abc");
                            byte loginResponseOpcode;
                            UserModel login = _packetReader.ReadObject<UserModel>();
                            User userlogin = userManagement.UserLogin(login.username, login.password);
                            if (userlogin == null) loginResponseOpcode = Constants.loginFailureOpCode;
                            else loginResponseOpcode = Constants.loginSuccessOpCode;
                            var loginResponse = new PacketBuilder();
                            loginResponse.WriteOpCode(loginResponseOpcode);
                            ClientSocket.Client.Send(loginResponse.GetPacketBytes());
                            break;

                        case Constants.registerOpCode:
                            byte registerResponseOpcode;
                            UserModel register = _packetReader.ReadObject<UserModel>();
                            User reg = new User
                            {
                                Username = register.username,
                                PasswordHash = register.password,
                                Email = register.email,
                                CreatedDate = DateTime.Now 

                            };
                            User userregister = userManagement.UserRegister(register.email);
                            if (userregister == null)
                            {
                                userManagement.AddUser(reg);
                                registerResponseOpcode = Constants.registerSuccessOpCode;
                            }
                            else registerResponseOpcode = Constants.registerFailureOpCode;
                            var registerResponse = new PacketBuilder();
                            registerResponse.WriteOpCode(registerResponseOpcode);
                            ClientSocket.Client.Send(registerResponse.GetPacketBytes());
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
