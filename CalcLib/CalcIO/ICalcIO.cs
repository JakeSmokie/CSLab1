using System;
using System.Collections.Generic;
using CSLabs.Operations;

namespace ClassLib
{
    public interface ICalcIO
    {
        double ReadDouble(Predicate<double> valueCorrectnessPredicate = null);
        int ReadInt(Predicate<int> valueCorrectnessPredicate = null);
        IOperation ReadOperation(List<IOperation> list);
        void Write(string msg);
        string ReadLine();
    }
}