using System;
using System.Collections.Generic;
using CSLabs.Operations;

namespace ClassLib.CalcIO
{
    public class CalcInputParser : ICalcInputParser
    {
        private ICalcIO _calcIO;

        public CalcInputParser(ICalcIO calcIO)
        {
            _calcIO = calcIO;
        }

        public double ReadDouble(Predicate<double> valueCorrectnessPredicate = null)
        {
            double result;
            _calcIO.Write("> ");

            string input;
            while (!double.TryParse(input = _calcIO.ReadString(), out result) || !(valueCorrectnessPredicate?.Invoke(result) ?? true))
            {
                _calcIO.Write("Wrong input. Try again.\n> ");
            }

            return result;
        }
        public int ReadInt(Predicate<int> valueCorrectnessPredicate = null)
        {
            int result;
            _calcIO.Write("#> ");

            string input;
            while (!int.TryParse(input = _calcIO.ReadString(), out result) || !(valueCorrectnessPredicate?.Invoke(result) ?? true))
            {
                _calcIO.Write("Wrong input. Try again.\n#> ");
            }

            return result;
        }
        public IOperation ReadOperation(List<IOperation> list)
        {
            _calcIO.Write("@: ");
            IOperation result = null;
            string input = _calcIO.ReadString().ToLower();

            while ((result = list.Find(x => x.OperatorChar.ToString() == input)) == null)
            {
                _calcIO.Write("Wrong input. Try again.\n@: ");
                input = _calcIO.ReadString().ToLower();
            }
            return result;
        }
    }
}
