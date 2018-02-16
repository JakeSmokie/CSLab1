using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class OperationsParser
    {
        public IOperation Read(List<IOperation> list)
        {
            bool correctKey = false;
            IOperation result = null;

            Console.Write("@: ");

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                var oper = list.Find(x => x.OperatorChar == input.KeyChar);

                if (oper != null)
                {
                    Console.WriteLine(input.KeyChar);
                    correctKey = true;

                    result = oper;
                }
            } while (!correctKey);

            return result;
        }
    }
}
