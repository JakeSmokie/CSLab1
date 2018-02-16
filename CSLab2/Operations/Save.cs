namespace CSLabs.Operations
{
    class Save : IOperation
    {
        public char OperatorChar { get => 's'; }
        public bool Run(MathBuffer mathBuffer)
        {
            return true;
        }
    }
}
