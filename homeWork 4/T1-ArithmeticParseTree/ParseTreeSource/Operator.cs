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
                _operator = op;
                _operation = ParseTree._operations[op];
            }

            public override string ToString() => $"( {_operator} {base.LeftNode} {base.RightNode})";
        }
    }
}