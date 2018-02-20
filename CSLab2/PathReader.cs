using ClassLib;
using System;
using System.IO;

namespace CSLabs
{
    class PathReader
    {
        private string FolderPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WolframFiles\";

        public string Read(CalcIn inStream, CalcOut outStream, Predicate<string> pathCorrectnessPredicate = null)
        {
            Directory.CreateDirectory(FolderPath);
            outStream.SendFilesInFolder(FolderPath);

            string finalName;

            do
            {
                finalName = FolderPath + inStream.GetFileName() + ".txt";
            } while (!(pathCorrectnessPredicate?.Invoke(finalName) ?? true));

            return finalName;
        }
    }
}
