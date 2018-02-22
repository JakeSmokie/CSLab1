using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class GenericProcessing
    {
        protected CalcIn inStream = new CalcIn();
        protected CalcOut outStream = new CalcOut();

        protected List<IOperation> operations = new List<IOperation>
        {
            new Add(),
            new Sub(),
            new Div(),
            new Mul(),
            new Jump(),
            new Exit()
        };

        protected MathBuffer mathBuffer;
        protected IOperation currentOperation = new SaveNumber();

        protected Action OnProcessingStart;

        protected Action OnOperationRead;
        protected Func<bool> OnOperationRun;

        public GenericProcessing()
        {
            mathBuffer = new MathBuffer(inStream, outStream);
            
            OnProcessingStart = () => outStream.SendGreeting();
            OnOperationRun    = () => currentOperation.Run(mathBuffer, inStream, outStream);
            OnOperationRead   = () => currentOperation = inStream.ReadOperation(operations);
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
