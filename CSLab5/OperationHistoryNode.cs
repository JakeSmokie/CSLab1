namespace CSLab5
{
    internal class OperationHistoryNode
    {
        public OperationHistoryNode(string text, double result)
        {
            Text = text;
            Result = result;
        }

        public string Text { get; private set; }
        public double Result { get; private set; }
    }
}
