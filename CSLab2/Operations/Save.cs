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
            var inStream = (CalcIn)args[1];
            var outStream = (CalcOut)args[2];

            using (var file = new StreamWriter(new PathReader().Read(inStream, outStream), false))
            {
                // Operations buffer
                ((List<string>)args[3]).ForEach(expression => file.WriteLine(expression));
            }

            return true;
        }
    }
}
