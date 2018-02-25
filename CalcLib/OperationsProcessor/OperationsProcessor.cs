using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class OperationsProcessor : IOperationsProcessor
    {
        public bool IsRunning { get; private set; }
        private ProcessorStorage Storage { get; set; }

        protected List<IOperation> Operations { get; set; }
        protected IOperation CurrentOperation { get; set; }

        protected Action ProcessingStartAction { get; set; }
        protected Action OperationReadAction { get; set; }
        protected Func<bool> OperationRunAction { get; set; }

        public OperationsProcessor()
        {
            IsRunning = false;

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

            ProcessingStartAction = () => Storage.CalcIO.SendGreeting();
            OperationRunAction = () => CurrentOperation.Run(Storage);
            OperationReadAction = () => CurrentOperation = Storage.CalcIO.ReadOperation(Operations);
        }

        public void Start()
        {
            if (IsRunning)
            {
                throw new Exception($"{ GetType().ToString() } is already running");
            }

            IsRunning = true;

            MyCultureInfo.Apply();
            ProcessingStartAction?.Invoke();

            while (OperationRunAction?.Invoke() ?? false)
            {
                OperationReadAction?.Invoke();
            }

            IsRunning = false;
        }
    }
}
