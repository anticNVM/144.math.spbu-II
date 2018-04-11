namespace ParseTreeSource
{
    public class Operator : Node
    {
        private string _operator;

        public Operator(string op) => _operator = op;

        public override string ToString() => $"( {_operator} {base.LeftNode} {base.RightNode})";
    }
}