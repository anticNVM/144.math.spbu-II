using System;

namespace ParseTreeSource
{
    public partial class ParseTree
    {
        private class Operator : Node
        {
            private string _operator;

            private Func<int, int, int> _operation;

            public Operator(string op)
            {
                var bar = new ParseTree();
                _operator = op;
                _operation = bar._operations[op];
            }

            public override int Evaluate() => _operation(base._leftNode.Evaluate(), base._rightNode.Evaluate());

            public override string ToString() => $"({base._leftNode} {_operator} {base._rightNode})";
        }
    }
}