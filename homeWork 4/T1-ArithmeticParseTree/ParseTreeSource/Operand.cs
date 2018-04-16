namespace ParseTreeSource
{
    public partial class ParseTree
    {
        /// <summary>
        /// Операнд (лист дерева)
        /// </summary>
        private class Operand : Node
        {
            /// <summary>
            /// Целочисленное значение
            /// </summary>
            private int _value;

            public Operand(int value) => _value = value;

            public override int Evaluate() => _value;

            public override string ToString() => _value.ToString();
        }
    }
}