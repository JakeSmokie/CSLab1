using ClassLib;
using CSLab2;
using System;
using System.IO;
using System.Text;

namespace CSLabs
{
    internal class PathReader : IPathReader
    {
        private string FolderPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WolframFiles\";

        public string Read(ICalcIO calcIO)
        {
            Directory.CreateDirectory(FolderPath);

            var stringBuilder = new StringBuilder("List of existing files:\n");

            foreach (string file in Directory.GetFiles(FolderPath, "*.txt"))
            {
                var str = file.Replace(FolderPath, "");
                stringBuilder.Append(str.Substring(0, str.LastIndexOf(".txt")));
                stringBuilder.Append("\n");
            }

            calcIO.WriteLine(stringBuilder.Append("Enter name of file:").ToString());

            var name = calcIO.ReadLine();
            return FolderPath + (string.IsNullOrWhiteSpace(name) ? "_" : name) + ".txt";
        }
    }
}
