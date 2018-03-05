using System.Collections.Generic;
using ClassLib;
using CSLabs;

namespace CSLab2
{
    public class OperationsHistory : IOperationsHistory
    {
        public List<string> Data { get; set; }

        public OperationsHistory()
        {
            Data = new List<string>();
        }

        public void Update(IOperationsProcessor processor, IProcessorStorage storage)
        {
            if (processor.CurrentOperation.OperatorChar.IsOneOf('l', 's', 'q'))
            {
                return;
            }

            string expression;

            switch (processor.CurrentOperation.OperatorChar)
            {
                case '\0':
                    expression = storage.Maths.Values[0].ToWolfString();
                    break;
                case '#':
                    expression = $"Out[{ storage.Maths.TempValue }]";
                    break;
                default:
                    expression = $"Out[-1] { processor.CurrentOperation.OperatorChar } { storage.Maths.TempValue.ToWolfString() } ";
                    break;
            }

            Data.Add(expression);
        }
    }
}
