namespace ParseTreeSource
{
    public partial class ParseTree
    {
        /// <summary>
        /// Узел дерева
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Левый сын
            /// </summary>
            public Node _leftNode;

            /// <summary>
            /// Правый сын
            /// </summary>
            public Node _rightNode;

            /// <summary>
            /// Посчитать значение выражения в поддереве
            /// </summary>
            /// <returns>Значение выражения в поддереве</returns>
            public virtual int Evaluate() => throw new System.NotImplementedException("ой ой ой");
        }
    }
}