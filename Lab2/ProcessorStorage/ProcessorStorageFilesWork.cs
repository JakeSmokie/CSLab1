using ClassLib;
using CSLabs;
using System.Collections.Generic;

namespace CSLab2
{
    public class ProcessorStorageFilesWork : IProcessorStorageFilesWork, IProcessorStorage
    {
        public IMathBuffer Maths { get; set; }
        public ICalcIO CalcIO { get; set; }
        public IOperationsHistory OperationsHistory { get; set; }
        public IExpressionParser MathExpressionParser { get; set; }
        public IPathReader FilePathReader { get; set; }

        public ProcessorStorageFilesWork(IMathBuffer maths, ICalcIO calcIO, IOperationsHistory operationsHistory, IExpressionParser mathExpressionParser, IPathReader filePathReader)
        {
            Maths = maths;
            CalcIO = calcIO;
            OperationsHistory = operationsHistory;
            MathExpressionParser = mathExpressionParser;
            FilePathReader = filePathReader;
        }
    }
}
