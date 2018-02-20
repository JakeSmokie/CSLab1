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
            using (var file = new StreamWriter(new PathReader().Read(">> ", overwriteCheck), false))
            {
                // Operations buffer
                ((List<string>)args[1]).ForEach(expression => file.WriteLine(expression));
            }

            return true;
        }

        private Predicate<string> overwriteCheck = delegate (string path)
        {
            if (!File.Exists(path))
            {
                return true;
            }

            Console.WriteLine($"Overwrite file {path} ? Press Y to confirm, any key to deny");
            
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                return true;
            }

            ConsoleUtils.CleanPreviousLine(0);
            return false;
        };
    }
}
