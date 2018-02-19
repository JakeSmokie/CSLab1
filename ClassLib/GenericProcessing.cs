using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class GenericProcessing
    {
        protected List<IOperation> operations = new List<IOperation>
        {
            new Add(),
            new Sub(),
            new Div(),
            new Mul(),
            new Jump(),
            new Exit()
        };

        protected MathBuffer mathBuffer = new MathBuffer();
        protected IOperation currentOperation = new SaveNumber();
        protected OperationsReader parser = new OperationsReader();

        public void Start()
        {
            MyCultureInfo.Apply();

            Console.WriteLine(
                "Usage:\n" +
                "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                "  when first symbol on line is ‘@’ – enter operation\n" +
                "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "    ‘#’ followed with number of evaluation step\n" +
                "    ‘q’ to exit");

            Loop();
        }

        public virtual void Loop()
        {
            while (currentOperation.Run(mathBuffer))
            {
                currentOperation = parser.Read(operations);
            }
        }
    }
}
