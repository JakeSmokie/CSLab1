using System;
using ClassLib;
using ClassLib.CalcIO;
using CSLab4Server;
using Grpc.Core;
using Labs;

namespace CSLab4Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
            var client = new MathsProccessor.MathsProccessorClient(channel);

            var calcIO = new ConsoleCalcIO();
            var parser = new CalcInputParser(calcIO);
            var processor = new ClientProcessor(client, calcIO, parser);

            try
            {
                // Test connection
                client.Set(new Arguments() { ID = "0", Input = 0 });
                processor.Start();
            }
            catch (RpcException e)
            {
                calcIO.WriteLine(e.Message);
                calcIO.ReadString();
            }

            channel.ShutdownAsync().Wait();
        }
    }
}
