using System.Collections.Generic;
using ClassLib;
using ClassLib.CalcIO;
using CSLabs;
using CSLabs.Operations;

namespace CSLab2
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            // ADD FACTORY
            var calcIO = new ConsoleCalcIO();
            var inputParser = new CalcInputParser(calcIO);
            var mathBuffer = new MathBuffer(calcIO);
            var history = new OperationsHistory();
            var expParser = new ExpressionParser();
            var pathReader = new PathReader();
            var storage = new ProcessorStorageFilesWork(mathBuffer, calcIO, history, expParser, pathReader, inputParser);
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

            processor.Start();
        }
    }
}
