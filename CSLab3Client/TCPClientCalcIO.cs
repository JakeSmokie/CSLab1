using System;
using System.Net.Sockets;
using System.Text;
using ClassLib;
using CSLab3Server;

namespace CSLab3Client
{
    internal class TCPClientCalcIO : ICalcIO
    {
        private ServerInfo _serverInfo;
        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private ICalcIO _clientCalcIO;

        public TCPClientCalcIO(ServerInfo serverInfo, ICalcIO clientCalcIO)
        {
            _serverInfo = serverInfo;
            _clientCalcIO = clientCalcIO;

            _tcpClient = new TcpClient();

            try
            {
                var task = _tcpClient.ConnectAsync(_serverInfo.IP, _serverInfo.Port);
                _clientCalcIO.WriteLine($"Connecting to {_serverInfo.IP}:{_serverInfo.Port}...");

                task.Wait();
                _stream = _tcpClient.GetStream();
            }
            catch (Exception e)
            {
                _clientCalcIO.WriteLine("Can't connect to server. Error: " + e.Message);
                _clientCalcIO.ReadString();

                Environment.Exit(-1);
            }
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

            return builder.ToString();
        }

        public void Write(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            _stream.Write(data, 0, data.Length);
        }

        public void WriteLine(string msg) => Write(msg + "\n");
    }
}