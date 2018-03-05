using CSLabs;

namespace CSLab2
{
    public interface IProcessorStorageFilesWork
    {
        IOperationsHistory OperationsHistory { get; set; }
        IPathReader FilePathReader { get; }
        IExpressionParser MathExpressionParser { get; }
    }
}
