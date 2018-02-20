using System;

namespace CSLabs.Operations
{
    public class Exit : IOperation
    {
        public char OperatorChar => 'q';
        public bool Run(params object[] args)
        {
            Console.Beep(440, 1000);
            return false;
        }
    }
}
