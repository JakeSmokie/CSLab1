using ClassLib;
using System;

namespace CSLabs.Operations
{
    internal class ExitOperation : IOperation
    {
        public char OperatorChar => 'q';
        public bool Run(IProcessorStorage storage)
        {
            Console.Beep(440, 1000);
            return false;
        }
    }
}
