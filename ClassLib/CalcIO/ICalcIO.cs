using System;
using System.Collections.Generic;
using CSLabs.Operations;

namespace ClassLib
{
    public interface ICalcIO
    {
        string GetFileName();
        double ReadDouble(Predicate<double> valueCorrectnessPredicate = null);
        int ReadInt(Predicate<int> valueCorrectnessPredicate = null);
        IOperation ReadOperation(List<IOperation> list);
        void SendDivideException();
        void SendFilesInFolder(string folder);
        void SendGreeting();
        void SendLoadResult(string msg);
        void SendMathAcc(string msg);
    }
}