using System;
using Grpc.Core;
using Labs;

namespace CSLab4Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int Port = 50052;

            var server = new Server()
            {
                Services =
                {
                    MathsProccessor.BindService(new MathsImpl())
                },
                Ports =
                {
                    new ServerPort("localhost", Port, ServerCredentials.Insecure)
                },
            };

            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
