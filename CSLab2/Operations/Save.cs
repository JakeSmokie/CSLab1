using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSLabs.Operations
{
    class Save : IOperation
    {
        public char OperatorChar => 's';
        public bool Run(params object[] args)
        {
            var inStream = (CalcIn)args[1];
            var outStream = (CalcOut)args[2];

            using (var file = new StreamWriter(new PathReader().Read(inStream, outStream), false))
            {
                // Operations buffer
                ((List<string>)args[3]).ForEach(expression => file.WriteLine(expression));
            }

            return true;
        }

        //private Predicate<string> overwriteCheck = delegate (string path)
        //{
        //    if (!File.Exists(path))
        //    {
        //        return true;
        //    }

        //    Console.WriteLine($"Overwrite file {path} ? Press Y to confirm, any key to deny");
            
        //    if (Console.ReadKey(true).Key == ConsoleKey.Y)
        //    {
        //        return true;
        //    }

        //    ConsoleUtils.CleanPreviousLine(0);
        //    return false;
        //};
    }
}
