using System.Collections.Generic;
using ClassLib;
using ClassLib.CalcIO;
using CSLabs.Operations;

namespace CSLabs
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            var calcIO = new ConsoleCalcIO();
            var inputParser = new CalcInputParser(calcIO);
            var mathBuffer = new MathBuffer(calcIO);
            var storage = new ProcessorStorage(mathBuffer, calcIO, inputParser);
            var firstOperation = new SaveNumberOperation();
            var operations = new List<IOperation>
            {
                new AddOperation(),
                new SubOperation(),
                new DivOperation(),
                new MulOperation(),
                new JumpOperation(),
                new ExitOperation()
            };

            var processor = new OperationsProcessor(storage, operations, firstOperation);

            processor.ProcessorPostStartAction += () => storage.CalcIO.Write(
                "Usage:\n" +
                "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                "  when first symbol on line is ‘@’ – enter operation\n" +
                "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "    ‘#’ followed with number of evaluation step\n" +
                "    ‘q’ to exit\n");

            processor.Start();
        }
    }
}

