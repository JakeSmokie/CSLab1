using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace ClassLib
{
    public class GenericProcessing
    {
        protected List<IOperation> operations;

        protected MathBuffer mathBuffer;
        protected IOperation currentOperation;
        protected OperationsParser parser;

        public GenericProcessing()
        {
            currentOperation = new SaveNumber();

            operations = new List<IOperation>
            {
                new Add(),
                new Sub(),
                new Div(),
                new Mul(),
                new Jump(),
                new Exit()
            };

            mathBuffer = new MathBuffer();
            parser = new OperationsParser();
        }

        public void Start()
        {
            Console.WriteLine(
                "Usage:\n" +
                "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                "  when first symbol on line is ‘@’ – enter operation\n" +
                "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "    ‘#’ followed with number of evaluation step\n" +
                "    ‘q’ to exit\n");

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
