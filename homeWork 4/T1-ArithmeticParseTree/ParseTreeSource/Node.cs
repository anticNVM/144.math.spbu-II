namespace ParseTreeSource
{
    public partial class ParseTree
    {
        private class Node
        {
            public Node _leftNode;
            public Node _rightNode;

            public virtual int Evaluate() => throw new System.NotImplementedException("ой ой ой");
        }
    }
}