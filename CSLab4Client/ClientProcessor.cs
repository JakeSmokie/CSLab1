using System;
using System.Collections.Generic;
using ClassLib;
using Labs;

namespace CSLab4Client
{
    public class ClientProcessor
    {
        private MathsProccessor.MathsProccessorClient client;
        private Dictionary<char, Func<Arguments, Result>> mathOperations;
        private Dictionary<char, Func<bool>> systemOperations;
        private int operationsCount;
        private string clientID;
        private ICalcIO calcIO;
        private ICalcInputParser parser;

        public ClientProcessor(MathsProccessor.MathsProccessorClient client, ICalcIO calcIO, ICalcInputParser parser)
        {
            this.client = client;
            this.calcIO = calcIO;
            this.parser = parser;

            operationsCount = 0;
            clientID = Guid.NewGuid().ToString();

            mathOperations = new Dictionary<char, Func<Arguments, Result>>
            {
                ['='] = (args) => client.Set(args),
                ['+'] = (args) => client.Add(args),
                ['-'] = (args) => client.Sub(args),
                ['*'] = (args) => client.Mul(args),
                ['/'] = (args) => client.Div(args),
            };

            systemOperations = new Dictionary<char, Func<bool>>
            {
                ['q'] = () => false,
                ['#'] = () =>
                {
                    var input = parser.ReadInt(x => x > 0 && x <= operationsCount);
                    var result = client.Jump(new Arguments() { ID = clientID, Input = input }).Value;

                    calcIO.WriteLine($"[#{++operationsCount}] = {result}");
                    return true;
                },
            };
        }

        public void Start()
        {
            calcIO.WriteLine(
                "Usage:\n" +
                "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                "  when first symbol on line is ‘@’ – enter operation\n");

            RunMathOperation(mathOperations['=']);

            bool running = true;
            while (running)
            {
                string input;

                do
                {
                    calcIO.Write("@: ");
                    input = calcIO.ReadString().Trim();
                } while (input.Length > 1 || string.IsNullOrWhiteSpace(input));

                if (mathOperations.TryGetValue(input[0], out var mathFunc))
                {
                    RunMathOperation(mathFunc);
                    continue;
                }

                if (systemOperations.TryGetValue(input[0], out var sysFunc))
                {
                    running = sysFunc();
                }
            }
        }

        private void RunMathOperation(Func<Arguments, Result> function)
        {
            double inputNumber = parser.ReadDouble();

            var result = function(new Arguments() { ID = clientID, Input = inputNumber }).Value;
            calcIO.WriteLine($"[#{++operationsCount}] = {result}");
        }
    }
}