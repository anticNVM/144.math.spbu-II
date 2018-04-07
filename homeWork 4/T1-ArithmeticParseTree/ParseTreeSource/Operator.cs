namespace ParseTreeSource
{
    public abstract class Operator : Node
    {
        public abstract char Op { get; }
        protected Node _leftNode;
        protected Node _rightNode;

        public override abstract int Evaluate();

        public override string ToString() => $"( {Op} {_leftNode.ToString()} {_rightNode.ToString()} )";
    }
}