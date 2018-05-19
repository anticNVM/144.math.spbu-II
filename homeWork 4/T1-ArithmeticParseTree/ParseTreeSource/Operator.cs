using System;

namespace ParseTreeSource
{
    public partial class ParseTree
    {
        /// <summary>
        /// Класс оператора
        /// </summary>
        private class Operator : Node
        {
            /// <summary>
            /// Строковый символ оператора
            /// </summary>
            private string _operator;

            /// <summary>
            /// Арифметическая операция, которую выполняет данный оператор
            /// </summary>
            private Func<int, int, int> _operation;

            public Operator(string op)
            {
                _operator = op;
                _operation = _operations[op];
            }

            public override int Evaluate() => _operation(base._leftNode.Evaluate(), base._rightNode.Evaluate());

            /// <summary>
            /// Представляет выражение в поддереве в инфиксной форме
            /// </summary>
            /// <returns>Строковое представление выражения</returns>
            public override string ToString() => $"({base._leftNode} {_operator} {base._rightNode})";
        }
    }
}