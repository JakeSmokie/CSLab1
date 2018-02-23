using ClassLib;
using System;
using System.IO;

namespace CSLabs
{
    class PathReader
    {
        private string FolderPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WolframFiles\";

        public string Read(ICalcIO inOutStream, Predicate<string> pathCorrectnessPredicate = null)
        {
            Directory.CreateDirectory(FolderPath);
            inOutStream.SendFilesInFolder(FolderPath);

            string finalName;

            do
            {
                finalName = FolderPath + inOutStream.GetFileName() + ".txt";
            } while (!(pathCorrectnessPredicate?.Invoke(finalName) ?? true));

            return finalName;
        }
    }
}
