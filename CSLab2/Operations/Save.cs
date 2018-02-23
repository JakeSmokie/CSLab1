using ClassLib;
using System.Collections.Generic;
using System.IO;

namespace CSLabs.Operations
{
    internal class Save : IOperation
    {
        public char OperatorChar => 's';
        public bool Run(params object[] args)
        {
            var inOutStream = (ICalcIO)args[1];

            using (var file = new StreamWriter(new PathReader().Read(inOutStream), false))
            {
                // Operations buffer
                ((List<string>)args[2]).ForEach(expression => file.WriteLine(expression));
            }

            return true;
        }
    }
}
