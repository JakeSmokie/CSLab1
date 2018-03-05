namespace ClassLib
{
    public interface ICalcIO
    {
        void Write(string msg);
        void WriteLine(string msg);
        string ReadString();
    }
}