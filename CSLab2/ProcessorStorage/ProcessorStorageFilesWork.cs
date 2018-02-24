using ClassLib;
using CSLabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab2
{
    internal class ProcessorStorageFilesWork : IProcessorStorageFilesWork, IProcessorStorage
    {
        public ProcessorStorageFilesWork()
        {
            CalcIO = new ConsoleCalcIOFilesWork();
            Maths = new MathBuffer(CalcIO);
            OperationsHistory = new List<string>();
            FilePathReader = new PathReader();
            MathExpressionParser = new ExpressionParser();
        }

        public IMathBuffer Maths { get; set; }
        public ICalcIO CalcIO { get; set; }
        public List<string> OperationsHistory { get; set; }
        public IExpressionParser MathExpressionParser { get; set; }
        public IPathReader FilePathReader { get; set; }
    }
}
