using ClassLib;
using CSLab2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSLabs.Operations
{
    internal class LoadOperation : IOperation
    {
        public char OperatorChar => 'l';
        public bool Run(IProcessorStorage storage)
        {
            IMathBuffer mathBuffer = storage.Maths;

            List<string> history = null;
            IPathReader pathReader = null;
            IExpressionParser expressionParser = null;

            if (storage is IProcessorStorageFilesWork ext)
            {
                history = ext.OperationsHistory;
                pathReader = ext.FilePathReader;
                expressionParser = ext.MathExpressionParser;
            }
            else
            {
                throw new ArgumentException();
            }

            var newOperBuffer = new List<string>();
            var valBuffer = new List<double>();
            ICalcIO calcIO = storage.CalcIO;

            using (var file = new StreamReader(pathReader.Read(calcIO)))
            {
                string expression, rawExpression;

                while ((rawExpression = expression = file.ReadLine()) != null)
                {
                    newOperBuffer.Add(expression);

                    double result = expressionParser.Parse(ref expression, valBuffer, calcIO);

                    if (double.IsNaN(result))
                    {
                        calcIO.Write("Parse error!\n");
                        return true;
                    }

                    calcIO.Write($"[#{ valBuffer.Count }] { rawExpression } = { (rawExpression != expression ? $"{ expression } = " : "") }{ result }\n");
                }
            }
                
            mathBuffer.Values = valBuffer;
            mathBuffer.AccValue = valBuffer.Last();

            history.Clear();
            history.AddRange(newOperBuffer);

            return true;
        }
    }
}
