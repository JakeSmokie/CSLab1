using ClassLib;
using System;
using System.IO;
using System.Text;

namespace CSLabs
{
    public class PathReader : IPathReader
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

            calcIO.Write(stringBuilder.Append("Enter name of file:\n").ToString());

            var name = calcIO.ReadString();
            return FolderPath + (string.IsNullOrWhiteSpace(name) ? "_" : name) + ".txt";
        }
    }
}
