using ClassLib;

namespace CSLabs.Operations
{
    public interface IOperation
    {
        char OperatorChar { get; }
        string Description { get; }

        bool Run(IProcessorStorage storage);
    }
}
