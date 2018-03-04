using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ClassLib
{
    public class OperationsProcessor : IOperationsProcessor
    {
        private IProcessorStorage Storage { get; set; }

        protected List<IOperation> Operations { get; set; }
        protected IOperation CurrentOperation { get; set; }

        protected Action ProcessingStartAction { get; set; }
        protected Action OperationReadAction { get; set; }
        protected Func<bool> OperationRunAction { get; set; }

        public OperationsProcessor()
        {
            Operations = new List<IOperation>
            {
                new AddOperation(),
                new SubOperation(),
                new DivOperation(),
                new MulOperation(),
                new JumpOperation(),
                new ExitOperation()
            };

            CurrentOperation = new SaveNumberOperation();
            Storage = new ProcessorStorage();

            OperationRunAction = () => CurrentOperation.Run(Storage);
            OperationReadAction = () => CurrentOperation = Storage.CalcIO.ReadOperation(Operations);
        }

        public void Start()
        {
            Storage.CalcIO.WriteLine("Usage:\n" +
                "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                "  when first symbol on line is ‘@’ – enter operation\n" +
                "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "    ‘#’ followed with number of evaluation step\n" +
                "    ‘q’ to exit");

            MyCultureInfo.Apply();
            ProcessingStartAction?.Invoke();

            while (OperationRunAction?.Invoke() ?? false)
            {
                OperationReadAction?.Invoke();
            }
        }
    }
}
