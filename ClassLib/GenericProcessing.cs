using CSLabs;
using CSLabs.Operations;
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

        public void Start()
        {
            mathBuffer = new MathBuffer(inStream, outStream);

            MyCultureInfo.Apply();
            outStream.SendGreeting();

            PostStart();

            while (RunOperation())
            {
                ReadOperation();
            }
        }

        protected virtual void PostStart() { }

        protected virtual bool RunOperation() => currentOperation.Run(mathBuffer, inStream, outStream);

        protected virtual void ReadOperation() => currentOperation = inStream.ReadOperation(operations);
    }
}
