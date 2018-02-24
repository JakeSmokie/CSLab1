using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab2
{
    public interface ICalcIOFilesWork
    {
        string ReadFileName();
        void SendFilesInFolder(string folder);
        void SendLoadResult(string msg);
        void SendParseError();
    }
}
