using ClassLib;
using CSLabs;

namespace CSLab2
{
    public class ProcessorStorageFilesWork : IProcessorStorageFilesWork, IProcessorStorage
    {
        public IMathBuffer Maths { get; set; }
        public ICalcIO CalcIO { get; set; }
        public IOperationsHistory OperationsHistory { get; set; }
        public IExpressionParser MathExpressionParser { get; private set; }
        public IPathReader FilePathReader { get; private set; }
        public ICalcInputParser InputParser { get; private set; }

        public ProcessorStorageFilesWork(IMathBuffer maths, ICalcIO calcIO, IOperationsHistory operationsHistory, IExpressionParser mathExpressionParser, IPathReader filePathReader, ICalcInputParser inputParser)
        {
            Maths = maths;
            CalcIO = calcIO;
            OperationsHistory = operationsHistory;
            MathExpressionParser = mathExpressionParser;
            FilePathReader = filePathReader;
            InputParser = inputParser;
        }
    }
}
