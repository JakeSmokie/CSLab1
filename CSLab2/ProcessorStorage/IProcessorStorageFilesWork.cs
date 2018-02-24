using CSLabs;
using System.Collections.Generic;

namespace CSLab2
{
    public interface IProcessorStorageFilesWork
    {
        List<string> OperationsHistory { get; set; }
        IPathReader FilePathReader { get; set; }
        IExpressionParser MathExpressionParser { get; set; }
    }
}
