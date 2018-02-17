using System;
using System.Collections.Generic;
using System.IO;

namespace CSLabs.Operations
{
    class Save : IOperation
    {
        public char OperatorChar { get => 's'; }
        public bool Run(params object[] args)
        {
            var buffer = (List<string>) args[1];
            buffer.ForEach(x => Console.WriteLine(x));

            return true;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WolframFiles\";
            Directory.CreateDirectory(path);

            string msg = "Enter name of file: ";
            Console.WriteLine(msg);

            string name;

            do
            {
                Utils.CleanPreviousLine(msg.Length);
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name) || name.Contains(@"\"));

            path += name + ".txt";

            using (var file = new StreamWriter(path, false))
            {

            }

            return true;
        }
    }
}
