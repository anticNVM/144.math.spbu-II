namespace ParseTreeSource
{
    public abstract class Node
    {
        public Node LeftNode { get; }
        public Node RightNode { get; }

        public abstract int Evaluate();

        public abstract override string ToString();
    }
}