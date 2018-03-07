using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ClassLib;

namespace CSLab3Client
{
    internal class Program
    {
        private static ICalcIO _clientCalcIO;
        private static TCPCalcIO _networkCalcIO;

        private static bool _programRunning;

        private static void Main(string[] args)
        {
            _programRunning = true;
            _clientCalcIO = new ConsoleCalcIO();

            var ipPoint = new IPEndPoint(IPAddress.Parse(args[0]), int.Parse(args[1]));
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(ipPoint);
            }
            catch (Exception e)
            {
                _clientCalcIO.WriteLine($"Can't connect to server {ipPoint}\nError: {e.Message}");
                _clientCalcIO.ReadString();

                return;
            }

            _networkCalcIO = new TCPCalcIO(socket, _clientCalcIO);

            var thread = new Thread(new ThreadStart(ReadServerMessages));
            thread.Start();

            thread = new Thread(new ThreadStart(CheckConnection));
            thread.Start();

            while (_programRunning)
            {
                string input = _clientCalcIO.ReadString().ToLower();

                if (input == "q")
                {
                    _programRunning = false;
                    _networkCalcIO.Disconnect();
                    return;
                }

                if (_programRunning)
                {
                    _networkCalcIO.Write(input); 
                }
            }
        }

        private static void CheckConnection()
        {
            var socket = _networkCalcIO.Handler;

            while (socket.Connected) { }

            _programRunning = false;
        }

        private static void ReadServerMessages()
        {
            while (_programRunning)
            {
                _clientCalcIO.Write(_networkCalcIO.ReadString());
            }
        }
    }
}
