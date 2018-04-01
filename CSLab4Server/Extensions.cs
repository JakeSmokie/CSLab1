namespace CSLab4Server
{
    public static class Extensions
    {
        public static bool IsIncorrectValue(this double val)
        {
            return
                double.IsNaN(val) ||
                double.IsInfinity(val);
        }
    }
}
