using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class OperationsProcessor : IOperationsProcessor
    {
        public List<IOperation> Operations { get; private set; }
        public IOperation CurrentOperation { get; private set; }

        public event Action ProcessorPostStartAction;
        public event Action OperationPreReadAction;

        private IProcessorStorage _storage;

        public OperationsProcessor(IProcessorStorage storage, List<IOperation> operations, IOperation firstOperation)
        {
            Operations = operations;

            CurrentOperation = firstOperation;
            _storage = storage;
        }

        public void Start()
        {
            try
            {
                Utils.SetDotAsDecimalSeparator();
                ProcessorPostStartAction?.Invoke();

                while (CurrentOperation.Run(_storage))
                {
                    OperationPreReadAction?.Invoke();
                    CurrentOperation = _storage.InputParser.ReadOperation(Operations);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
