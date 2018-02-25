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
