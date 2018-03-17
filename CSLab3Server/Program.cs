using System.Collections.Generic;
using System.Threading;
using ClassLib;
using ClassLib.CalcIO;
using CSLabs;
using CSLabs.Operations;
using CSLab2;
using CSLab3Client;
using System.Net;
using System.Net.Sockets;

namespace CSLab3Server
{
    internal class Program
    {
        private static bool _programRunning;
        private static ICalcIO _consoleCalcIO;
        private static List<TCPCalcIO> _clientCalcIO;
        private static List<Thread> _clientThreads;
        private static Socket _listenSocket;
        private static Thread _connectThread;

        private static void Main(string[] args)
        {
            _programRunning = true;
            _consoleCalcIO = new ConsoleCalcIO();
            _clientCalcIO = new List<TCPCalcIO>();
            _clientThreads = new List<Thread>();

            var ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse(args[0]));
            _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _consoleCalcIO.WriteLine("Server started at port " + args[0]);

            _listenSocket.Bind(ipPoint);
            _listenSocket.Listen(10);

            _connectThread = new Thread(new ThreadStart(ConnectionsThread));
            _connectThread.Start();

            while (_programRunning)
            {
                _consoleCalcIO.ReadString();
            }
        }

        private static void ConnectionsThread()
        {
            while (_programRunning)
            {
                var socket = _listenSocket.Accept();
                ConnectClient(socket);
            }
        }

        public static void ConnectClient(Socket clientSocket)
        {
            var clientCalcIO = new TCPCalcIO(clientSocket, _consoleCalcIO);

            _clientCalcIO.Add(clientCalcIO);

            var expParser = new ExpressionParser();
            var pathReader = new PathReader();
            var firstOperation = new SaveNumberOperation();
            var operations = new List<IOperation>
            {
                new AddOperation(),
                new SubstractOperation(),
                new DivideOperation(),
                new MultiplyOperation(),
                new JumpOperation(),
                new ExitOperation(),
                new LoadOperation(),
                new SaveOperation()
            };
            var inputParser = new CalcInputParser(clientCalcIO);
            var mathBuffer = new MathBuffer(clientCalcIO);
            var history = new OperationsHistory();
            var storage = new ProcessorStorageFilesWork(mathBuffer, clientCalcIO, history, expParser, pathReader, inputParser);
            var processor = new OperationsProcessor(storage, operations, firstOperation);

            processor.ProcessorPostStartAction += () => storage.CalcIO.Write(
                "Calc - net version\n" +
                "Usage:\n" +
                "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                "  when first symbol on line is ‘@’ – enter operation\n" +
                "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "    ‘#’ followed with number of evaluation step\n" +
                "    ‘q’ to exit\n" +
                "    ‘l’ to load file, ‘s’ to save\n");

            processor.OperationPreReadAction += () => history.Update(processor, storage);

            var thread = new Thread(new ThreadStart(processor.Start));
            _clientThreads.Add(thread);  

            thread.Start();
        }
    }
}
