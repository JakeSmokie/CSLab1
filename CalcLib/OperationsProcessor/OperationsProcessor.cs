using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class OperationsProcessor : IOperationsProcessor
    {
        protected IProcessorStorage Storage { get; set; }
        protected List<IOperation> Operations { get; set; }
        protected IOperation CurrentOperation { get; set; }

        protected event Action processorPostStartAction;
        protected event Action operationPreReadAction;

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
            processorPostStartAction?.Invoke();

            while (CurrentOperation.Run(Storage))
            {
                operationPreReadAction?.Invoke();
                CurrentOperation = Storage.CalcIO.ReadOperation(Operations);
            }
        }
    }
}
