using ClassLib;
using CSLabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab2
{
    public interface IProcessorStorageFilesWork
    {
        List<string> OperationsHistory { get; set; }
        IPathReader FilePathReader { get; set; }
        IExpressionParser MathExpressionParser { get; set; }
    }
}
