namespace CSLabs.Operations
{
    class Load : IOperation
    {
        public char OperatorChar { get => 'l'; }
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
