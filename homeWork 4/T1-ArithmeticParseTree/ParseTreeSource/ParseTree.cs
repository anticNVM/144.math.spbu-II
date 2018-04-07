namespace ParseTreeSource
{
    public class ParseTree : Node
    {
        private Node _root;

        protected ParseTree(string expression)
        {
        }

        public override int Evaluate() => _root.Evaluate();

        public override string ToString() => $"( {_root.ToString()} )";
    }
}