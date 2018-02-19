using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSLabs.Operations
{
    class Load : IOperation
    {
        public char OperatorChar { get => 'l'; }
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
            var newMBuffer = new MathBuffer();

            var operationsBuffer = (List<string>)args[1];
            var newOperBuffer = new List<string>();

            using (var file = new StreamReader(new PathReader().Read("<< ", s => File.Exists(s))))
            {
                string expression, rawExpression;

                while ((rawExpression = expression = file.ReadLine()) != null)
                {
                    newOperBuffer.Add(expression);

                    double result = new ExpressionParser().Parse(ref expression, newMBuffer);

                    Console.WriteLine($"[#{ newMBuffer.values.Count }] { rawExpression } = " +
                        (rawExpression != expression ? $"{ expression } = " : "") + result);
                }
            }

            mathBuffer.values = newMBuffer.values;
            mathBuffer.AccValue = newMBuffer.values.Last();

            operationsBuffer.Clear();
            operationsBuffer.AddRange(newOperBuffer);

            return true;
        }
    }
}
