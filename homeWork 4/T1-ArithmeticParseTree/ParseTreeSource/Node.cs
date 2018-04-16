namespace ParseTreeSource
{
    public partial class ParseTree
    {
        private class Node
        {
            public Node LeftNode { get; }
            public Node RightNode { get; }

            public virtual int Evaluate() => throw new System.NotImplementedException("ой ой ой");
        }
    }
}