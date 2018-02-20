using System;
using System.IO;

namespace ClassLib
{
    public class CalcOut
    {
        public virtual void SendMathAcc(string msg) => Console.WriteLine(msg);
        public virtual void SendGreeting() => Console.WriteLine(
            "Usage:\n" +
            "  when first symbol on line is ‘>’ – enter operand(number)\n" +
            "  when first symbol on line is ‘@’ – enter operation\n" +
            "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
            "    ‘#’ followed with number of evaluation step\n" +
            "    ‘q’ to exit");
        public virtual void SendDivideException() => Console.WriteLine(new DivideByZeroException().Message);

        public virtual void SendFilesInFolder(string folder)
        {
            Console.WriteLine("List of existing files:");

            foreach (string file in Directory.GetFiles(folder, "*.txt"))
            {
                Console.WriteLine(" * " + file.Replace(folder, "").Replace(".txt", ""));
            }

            Console.WriteLine(
                "Enter name of file. \n" +
                "<< ");
        }

        public virtual void SendLoadResult(string msg) => Console.WriteLine(msg);
    }
}
