using ClassLib;
using CSLab2;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSLabs.Operations
{
    public class SaveOperation : IOperation
    {
        public char OperatorChar => 's';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            List<string> history = null;

            if (storage is IProcessorStorageFilesWork ext)
            {
                history = ext.OperationsHistory.Data;
            }
            else
            {
                throw new ArgumentException();
            }

            using (var file = new StreamWriter(new PathReader().Read(calcIO), false))
            {
                // Operations buffer
                history.ForEach(expression => file.WriteLine(expression));
            }

            return true;
        }
    }
}
