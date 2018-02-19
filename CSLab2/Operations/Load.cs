using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace CSLabs.Operations
{
    class Load : IOperation
    {
        private Dictionary<string, string> replaceDictionary = new Dictionary<string, string>()
        {
            ["["]       = "(",
            ["]"]       = ")",
            ["Sqrt"]    = "Math.Sqrt"
        };

        public char OperatorChar { get => 'l'; }
        public bool Run(params object[] args)
        {
            var file = new StreamReader(new PathReader().Read(s => File.Exists(s)));

            var mathBuffer = (MathBuffer)args[0];
            var newMBuffer = new MathBuffer();

            var operationsBuffer = (List<string>)args[1];
            var newOperBuffer = new List<string>();

            string expression;

            while ((expression = file.ReadLine()) != null)
            {
                newOperBuffer.Add(expression);

                foreach (var pair in replaceDictionary)
                {
                    expression = expression.Replace(pair.Key, pair.Value);
                }

                var outFuncMatches = Regex.Matches(expression, @"Out\(-?\d*\)");

                foreach (Match match in outFuncMatches)
                {
                    string old = match.Value;

                    if (!int.TryParse(old.Replace("Out(", "").Replace(")", ""), out int index))
                    {
                        break;
                    }

                    if (index < 0)
                    {
                        index = newMBuffer.values.Count + index + 1;
                    }

                    expression = expression.Replace(old, "" + newMBuffer.values[index - 1]);
                }

                double result = double.NaN;

                try
                {
                    result = (double)System.Linq.Dynamic.DynamicExpression.ParseLambda(new ParameterExpression[0], typeof(double), expression).Compile()?.DynamicInvoke();
                    newMBuffer.values.Add(result);
                }
                catch (System.Linq.Dynamic.ParseException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine($"[#{ newMBuffer.values.Count }] { newOperBuffer[newOperBuffer.Count - 1] } = " +
                    (outFuncMatches.Count > 0 ? $"{ expression } = " : "") + result);
            }

            file.Dispose();

            mathBuffer.values = newMBuffer.values;
            mathBuffer.AccValue = newMBuffer.values[newMBuffer.values.Count - 1];

            operationsBuffer.Clear();
            operationsBuffer.AddRange(newOperBuffer);

            return true;
        }
    }
}
