using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq.Expressions;

namespace CSLabs
{
    class ExpressionParser
    {
        private Dictionary<string, string> replaceDictionary = new Dictionary<string, string>()
        {
            ["["] = "(",
            ["]"] = ")",
            ["Sqrt"] = "Math.Sqrt"
        };

        public double Parse(ref string expression, MathBuffer mathBuffer)
        {
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
                    index = mathBuffer.values.Count + index + 1;
                }

                expression = expression.Replace(old, "" + mathBuffer.values[index - 1]);
            }

            double result = double.NaN;

            try
            {
                result = (double)System.Linq.Dynamic.DynamicExpression.ParseLambda(new ParameterExpression[0], typeof(double), expression).Compile()?.DynamicInvoke();
                mathBuffer.values.Add(result);
            }
            catch (System.Linq.Dynamic.ParseException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}
