using System.Collections.Generic;
using System.Linq;
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
                new SubstractOperation(),
                new DivideOperation(),
                new MultiplyOperation(),
                new JumpOperation(),
                new ExitOperation()
            };

            var processor = new OperationsProcessor(storage, operations, firstOperation);

            processor.Start();
        }
    }
}

