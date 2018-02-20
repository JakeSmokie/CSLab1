using System;
using System.IO;

namespace CSLabs
{
    class PathReader
    {
        private string FolderPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WolframFiles\";

        public string Read(string msg, Predicate<string> pathCorrectnessPredicate = null)
        {
            Directory.CreateDirectory(FolderPath);
            PrintExistFiles();

            Console.WriteLine(
                "Enter name of file. \n" +
                msg);

            string name, finalName;

            do
            {
                do
                {
                    ConsoleUtils.CleanPreviousLine(msg.Length);
                    name = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(name));

                finalName = FolderPath + name + ".txt";
            } while (!(pathCorrectnessPredicate?.Invoke(finalName) ?? true));

            return finalName;
        }

        private void PrintExistFiles()
        {
            Console.WriteLine("List of existing files:");

            foreach (string file in Directory.GetFiles(FolderPath, "*.txt"))
            {
                Console.WriteLine(" * " + file.Replace(FolderPath, "").Replace(".txt", ""));
            }
        }
    }
}
