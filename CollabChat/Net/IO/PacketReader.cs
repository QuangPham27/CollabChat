using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.Net.IO
{
    public class PacketReader : BinaryReader
    {
        private NetworkStream _ns;
        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }
        public T ReadObject<T>()
        {
            var length = ReadInt32();
            var jsonBytes = new byte[length];
            _ns.Read(jsonBytes, 0, length);

            var json = Encoding.UTF8.GetString(jsonBytes);
            var obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

    }
}
