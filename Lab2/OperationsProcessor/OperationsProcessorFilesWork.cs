using ClassLib;
using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace CSLab2
{
    internal class OperationsProcessorFilesWork : OperationsProcessor
    {
        public OperationsProcessorFilesWork()
        {
            Storage = new ProcessorStorageFilesWork();

            Operations.AddRange(new List<IOperation>
            {
                new Load(),
                new Save()
            });

            processorPostStartAction += () => Console.WriteLine("    ‘l’ to load file, ‘s’ to save");
            operationPreReadAction += UpdateOperationsBuffer;
        }

        private void UpdateOperationsBuffer()
        {
            if (CurrentOperation.OperatorChar.IsOneOf('l', 's', 'q'))
            {
                return;
            }
            
            string expression;

            switch (CurrentOperation.OperatorChar)
            {
                case '\0':
                    expression = Storage.Maths.Values[0].ToWolfString();
                    break;  
                case '#':
                    expression = $"Out[{ Storage.Maths.TempValue }]";
                    break;
                default:
                    expression = $"Out[-1] { CurrentOperation.OperatorChar } { Storage.Maths.TempValue.ToWolfString() } ";
                    break;
            }

            (Storage as IProcessorStorageFilesWork)?.OperationsHistory.Add(expression);
        }
    }
}
