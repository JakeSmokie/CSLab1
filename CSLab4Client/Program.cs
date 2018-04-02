using ClassLib;
using ClassLib.CalcIO;
using Grpc.Core;
using Labs;

namespace CSLab4Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ip = args[0];
            var port = args[1];

            var channel = new Channel($"{ip}:{port}", ChannelCredentials.Insecure);
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
                calcIO.WriteLine($"Error: {e.Status.Detail}");
                calcIO.ReadString();
            }

            channel.ShutdownAsync().Wait();
        }
    }
}
