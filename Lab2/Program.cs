using System.Collections.Generic;
using ClassLib;
using CSLabs;
using CSLabs.Operations;

namespace CSLab2
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            var calcIO = new ConsoleCalcIO();
            var mathBuffer = new MathBuffer(calcIO);
            var history = new List<string>();
            var expParser = new ExpressionParser();
            var pathReader = new PathReader();
            var storage = new ProcessorStorageFilesWork(mathBuffer, calcIO, history, expParser, pathReader);
            var firstOperation = new SaveNumberOperation();
            var operations = new List<IOperation>
            {
                new AddOperation(),
                new SubOperation(),
                new DivOperation(),
                new MulOperation(),
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

            processor.OperationPreReadAction += () =>
            {
                if (processor.CurrentOperation.OperatorChar.IsOneOf('l', 's', 'q'))
                {
                    return;
                }

                string expression;

                switch (processor.CurrentOperation.OperatorChar)
                {
                    case '\0':
                        expression = storage.Maths.Values[0].ToWolfString();
                        break;
                    case '#':
                        expression = $"Out[{ storage.Maths.TempValue }]";
                        break;
                    default:
                        expression = $"Out[-1] { processor.CurrentOperation.OperatorChar } { storage.Maths.TempValue.ToWolfString() } ";
                        break;
                }

                (storage as IProcessorStorageFilesWork)?.OperationsHistory.Add(expression);
            };

            processor.Start();
        }
    }
}
