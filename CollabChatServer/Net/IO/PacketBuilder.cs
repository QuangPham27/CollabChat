using Newtonsoft.Json;
using System.Text;

namespace CollabChatServer.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }
        public void WriteObject<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var jsonBytes = Encoding.UTF8.GetBytes(json);

            _ms.Write(BitConverter.GetBytes(jsonBytes.Length));
            _ms.Write(jsonBytes);
        }

        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
