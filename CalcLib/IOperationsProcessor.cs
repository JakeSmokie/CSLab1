using System;
using System.Collections.Generic;
using CSLabs.Operations;

namespace ClassLib
{
    public interface IOperationsProcessor
    {
        IOperation CurrentOperation { get; }
        List<IOperation> Operations { get; }

        event Action OperationPreReadAction;

        void Start();
    }
}