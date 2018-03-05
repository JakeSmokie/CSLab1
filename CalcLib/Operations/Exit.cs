using ClassLib;

namespace CSLabs.Operations
{
    public class ExitOperation : IOperation
    {
        public char OperatorChar => 'q';
        public bool Run(IProcessorStorage storage)
        {
            return false;
        }
    }
}
