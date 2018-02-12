﻿using CSLab1.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLab1
{
    class Instruction
    {
        public delegate void Action();
        private Action action;

        public Instruction(Action a)
        {
            action = a;
        }
    }
    class Processing
    {
        private List<IOperation> operations;
        private IOperation currentOperation;
        private MathBuffer mathBuffer;

        public Processing()
        {
            currentOperation = new SaveInput();

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

            bool exit = false;

            do
            {
                exit = currentOperation.Run(mathBuffer);

                if (!currentOperation.OperatorChar.IsOneOf('q'))
                {
                    GetOperation();
                }
            } while (!exit);
        }

        private void GetOperation()
        {
            bool correctKey = false;

            Console.Write("@: ");

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                var oper = operations.Find(x => x.OperatorChar == input.KeyChar);

                if (oper != null)
                {
                    Console.WriteLine(input.KeyChar);
                    correctKey = true;

                    currentOperation = oper;
                }
            } while (!correctKey);
        }
    }
}
