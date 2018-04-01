using ClassLib;

namespace CSLabs.Operations
{
    public class ExitOperation : IOperation
    {
        public char OperatorChar => 'q';
        public string Description => "exit";
        public bool Run(IProcessorStorage storage)
        {
            return false;
        }
    }
}
