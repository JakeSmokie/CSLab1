using ClassLib;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace CSLabs
{
    class Processing : GenericProcessing
    {
        private List<string> operationsBuffer = new List<string>();

        public Processing() : base()
        {
            operations.AddRange(new List<IOperation>
            {
                new Load(),
                new Save()
            });

            OnProcessingStart += () => Console.WriteLine("    ‘l’ to load file, ‘s’ to save");

            OnOperationRun = () => currentOperation.Run(mathBuffer, inStream, outStream, operationsBuffer);
            OnOperationRead = UpdateOperationsBuffer + OnOperationRead;
        }

        private void UpdateOperationsBuffer()
        {
            if (currentOperation.OperatorChar.IsOneOf('l', 's', 'q'))
            {
                return;
            }
            
            string expression;

            switch (currentOperation.OperatorChar)
            {
                case '\0':
                    expression = mathBuffer.values[0].ToWolfString();
                    break;  
                case '#':
                    expression = $"Out[{ mathBuffer.TempValue }]";
                    break;
                default:
                    expression = $"Out[-1] { currentOperation.OperatorChar } { mathBuffer.TempValue.ToWolfString() } ";
                    break;
            }

            operationsBuffer.Add(expression);
        }
    }
}
