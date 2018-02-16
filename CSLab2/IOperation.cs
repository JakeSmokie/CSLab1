namespace CSLab1.Operations
{
    interface IOperation
    {
        char OperatorChar { get; }

        bool Run(MathBuffer mathBuffer);
    }
}
