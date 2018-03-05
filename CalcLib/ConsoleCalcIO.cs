using System;

namespace ClassLib
{
    public class ConsoleCalcIO : ICalcIO
    {
        public void Write(string msg) => Console.Write(msg);
        public void WriteLine(string msg) => Write(msg + "\n");
        public string ReadString() => Console.ReadLine();
    }
}
