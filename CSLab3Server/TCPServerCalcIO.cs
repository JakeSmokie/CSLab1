using System.Net.Sockets;
using System.Text;
using ClassLib;

namespace CSLab3Server
{
    public class TCPServerCalcIO : ICalcIO
    {
        private TcpClient _tcpClient;
        private NetworkStream _stream;

        public TCPServerCalcIO(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            _stream = _tcpClient.GetStream();
        }

        public string ReadString()
        {
            var data = new byte[64];
            var builder = new StringBuilder();
            var bytes = 0;

            do
            {
                bytes = _stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (_stream.DataAvailable);

            return builder.ToString().Replace("\n", "");
        }

        public void Write(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            _stream.Write(data, 0, data.Length);
        }

        public void WriteLine(string msg) => Write(msg + "\n");
    }
}