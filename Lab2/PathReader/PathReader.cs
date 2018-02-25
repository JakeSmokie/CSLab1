using ClassLib;
using CSLab2;
using System;
using System.IO;

namespace CSLabs
{
    internal class PathReader : IPathReader
    {
        private string FolderPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WolframFiles\";

        public string Read(ICalcIO calcIO, Predicate<string> pathCorrectnessPredicate = null)
        {
            var inOutStream = (ICalcIOFilesWork)calcIO;

            Directory.CreateDirectory(FolderPath);
            inOutStream.SendFilesInFolder(FolderPath);

            string finalName;

            do
            {
                finalName = FolderPath + inOutStream.ReadFileName() + ".txt";
            } while (!(pathCorrectnessPredicate?.Invoke(finalName) ?? true));

            return finalName;
        }
    }
}
