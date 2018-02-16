using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class GenericProcessing
    {
        protected List<IOperation> operations;
        private IOperation currentOperation;
        private MathBuffer mathBuffer;
        private OperationsParser parser;

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

            while (currentOperation.Run(mathBuffer))
            {
                currentOperation = parser.Read(operations);
            } 
        }
    }
}
