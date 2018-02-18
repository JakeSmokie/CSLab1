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
            string path = new PathReader().Read(overwriteCheck);

            using (var file = new StreamWriter(path, false))
            {
                buffer.ForEach(expression => file.WriteLine(expression));
            }

            return true;
        }

        private Predicate<string> overwriteCheck = delegate (string s)
        {
            if (!File.Exists(s))
            {
                return true;
            }

            Console.WriteLine($"Overwrite file {s} ? Press Y to confirm, any key to deny");
            
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                return true;
            }

            Utils.CleanPreviousLine(0);
            return false;
        };
    }
}
