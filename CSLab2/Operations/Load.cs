using ClassLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSLabs.Operations
{
    internal class Load : IOperation
    {
        public char OperatorChar => 'l';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
            var valBuffer = new List<double>();

            var inStream = (CalcIn)args[1];
            var outStream = (CalcOut)args[2];

            var operationsBuffer = (List<string>)args[3];
            var newOperBuffer = new List<string>();

            using (var file = new StreamReader(new PathReader().Read(inStream, outStream, s => File.Exists(s))))
            {
                string expression, rawExpression;

                while ((rawExpression = expression = file.ReadLine()) != null)
                {
                    newOperBuffer.Add(expression);

                    double result = new ExpressionParser().Parse(ref expression, valBuffer);

                    outStream.SendLoadResult($"[#{ valBuffer.Count }] { rawExpression } = " +
                        (rawExpression != expression ? $"{ expression } = " : "") + result);
                }
            }

            mathBuffer.values = valBuffer;
            mathBuffer.AccValue = valBuffer.Last();

            operationsBuffer.Clear();
            operationsBuffer.AddRange(newOperBuffer);

            return true;
        }
    }
}
