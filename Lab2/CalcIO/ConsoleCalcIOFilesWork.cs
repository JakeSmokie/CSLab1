using ClassLib;
using CSLabs;
using System;
using System.IO;

namespace CSLab2
{
    internal class ConsoleCalcIOFilesWork : ConsoleCalcIO, ICalcIOFilesWork
    {
        public void SendFilesInFolder(string folder)
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

        public void SendLoadResult(string msg) => Console.WriteLine(msg);

        public string ReadFileName()
        {
            string name;

            do
            {
                ConsoleUtils.CleanPreviousLine(3);
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        public void SendParseError() => Console.WriteLine("Parse error!");
    }
}
