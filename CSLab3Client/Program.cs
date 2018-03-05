using System.Threading;
using ClassLib;
using CSLab3Server;

namespace CSLab3Client
{
    internal class Program
    {
        private static ICalcIO _clientCalcIO;
        private static ICalcIO _networkCalcIO;

        private static bool _programRunning;

        private static void Main(string[] args)
        {
            _programRunning = true;

            var serverInfo = new ServerInfo
            {
                IP = args[0],
                Port = int.Parse(args[1])
            };

            _clientCalcIO = new ConsoleCalcIO();
            _networkCalcIO = new TCPClientCalcIO(serverInfo, _clientCalcIO);

            var thread = new Thread(new ThreadStart(ReadServerMessages));
            thread.Start();

            while (_programRunning)
            {
                string input = _clientCalcIO.ReadString().ToLower();

                if (input == "q")
                {
                    _programRunning = false;
                }

                _networkCalcIO.Write(input);
            }
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
