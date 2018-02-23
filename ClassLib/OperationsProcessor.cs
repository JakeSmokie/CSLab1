using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class OperationsProcessor
    {
        protected ICalcIO inOutStream = new ConsoleCalcIO();

        protected List<IOperation> operations = new List<IOperation>
        {
            new Add(),
            new Sub(),
            new Div(),
            new Mul(),
            new Jump(),
            new Exit()
        };

        protected IOperation currentOperation = new SaveNumber();
        protected MathBuffer mathBuffer;

        protected Action OnProcessingStart;
        protected Action OnOperationRead;
        protected Func<bool> OnOperationRun;

        public OperationsProcessor()
        {
            mathBuffer = new MathBuffer(inOutStream);

            OnProcessingStart = () => inOutStream.SendGreeting();
            OnOperationRun = () => currentOperation.Run(mathBuffer, inOutStream);
            OnOperationRead = () => currentOperation = inOutStream.ReadOperation(operations);
        }

        public void Start()
        {
            MyCultureInfo.Apply();
            OnProcessingStart?.Invoke();

            while (OnOperationRun?.Invoke() ?? false)
            {
                OnOperationRead?.Invoke();
            }
        }
    }
}
