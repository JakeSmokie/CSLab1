namespace ClassLib
{
    public interface IOperationsProcessor
    {
        bool IsRunning { get; }

        void Start();
    }
}