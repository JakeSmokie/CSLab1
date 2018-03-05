using System.Collections.Generic;
using ClassLib;

namespace CSLab2
{
    public interface IOperationsHistory
    {
        List<string> Data { get; set; }

        void Update(IOperationsProcessor processor, IProcessorStorage storage);
    }
}