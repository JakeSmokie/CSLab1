using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ClassLib;
using ClassLib.CalcIO;
using CSLabs;
using CSLabs.Operations;
using CSLab2;

namespace CSLab3Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var expParser = new ExpressionParser();
            var pathReader = new PathReader();
            var consoleCalcIO = new ConsoleCalcIO();
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

            var tcpListener = new TcpListener(IPAddress.Any, int.Parse(args[0]));
            tcpListener.Start();

            consoleCalcIO.WriteLine("Server started at port " + args[0]);

            while (true)
            {
                var tcpClient = tcpListener.AcceptTcpClient();
                var clientCalcIO = new TCPServerCalcIO(tcpClient);

                // ADD FACTORY
                var inputParser = new CalcInputParser(clientCalcIO);
                var mathBuffer = new MathBuffer(clientCalcIO);
                var history = new OperationsHistory();
                
                var storage = new ProcessorStorageFilesWork(mathBuffer, clientCalcIO, history, expParser, pathReader, inputParser);
                var processor = new OperationsProcessor(storage, operations, firstOperation);

                processor.ProcessorPostStartAction += () => storage.CalcIO.Write(
                    "Usage:\n" +
                    "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                    "  when first symbol on line is ‘@’ – enter operation\n" +
                    "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                    "    ‘#’ followed with number of evaluation step\n" +
                    "    ‘q’ to exit\n" +
                    "    ‘l’ to load file, ‘s’ to save\n");

                processor.OperationPreReadAction += () => history.Update(processor, storage);

                var thread = new Thread(new ThreadStart(processor.Start));
                thread.Start();
            }
        }
    }
}
