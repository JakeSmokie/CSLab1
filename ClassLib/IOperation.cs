namespace CSLabs.Operations
{
    public interface IOperation
    {
        char OperatorChar { get; }

        bool Run(MathBuffer mathBuffer);
    }
}
