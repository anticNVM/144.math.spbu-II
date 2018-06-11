namespace ParseTreeSource
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Дерево разбора, вычисляющее значение арифметического выражения по его представлению в виде дерева 
    /// </summary>
    public partial class ParseTree : IParseTree
    {
        /// <summary>
        /// Корень дерева
        /// </summary>
        private Node _root;

        /// <summary>
        /// Таблица арифметических опереторов для данного дерева разбора
        /// </summary>
        private TableOfOperations _table;

        public ParseTree(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                _root = new Operand(0);
                return;
            }

            _table = new TableOfOperations();

            var tokens = expression.Split(' ');
            var iter = GetSequence(tokens);
            BuildTree(ref _root, iter);
        }

        /// <summary>
        /// Считает значение выражения, хранимого в дереве
        /// </summary>
        /// <returns>Значение арифметического выражения</returns>
        public int Evaluate() => _root.Evaluate();

        /// <summary>
        /// Строковое значение выражения
        /// </summary>
        /// <returns>Выражение в инфиксной записи</returns>
        public override string ToString() => _root.ToString();

        /// <summary>
        /// Рекурсивно строит дерево по корректной последовательности символов
        /// </summary>
        /// <param name="node"></param>
        /// <param name="iter"></param>
        private void BuildTree(ref Node node, IEnumerator<string> iter)
        {
            var current = iter.GetNext();
            if (current == ")")
            {
                current = iter.GetNext();
            }
            // если (, тогда след за ним это оператор
            if (current == "(")
            {
                node = new Operator(iter.GetNext(), _table);
                BuildTree(ref (node as Operator)._leftNode, iter);
                BuildTree(ref (node as Operator)._rightNode, iter);
            }
            // тогда это число
            else if (int.TryParse(current, out int value))
            {
                node = new Operand(value);
            }
        }


        private IEnumerator<string> GetSequence(string[] tokens)
        {
            foreach (var token in tokens)
            {
                yield return token;
            }
        }

        /// <summary>
        /// Узел дерева (абстрактный класс)
        /// </summary>
        private abstract class Node
        {
            /// <summary>
            /// Считает значение выражения в поддереве
            /// </summary>
            /// <returns>Значение выражения в поддереве</returns>
            public abstract int Evaluate(); // Абстрактный метод неявно представляет собой виртуальный метод!!
        }

        /// <summary>
        /// Класс Операнда (лист дерева)
        /// </summary>
        private class Operand : Node
        {
            /// <summary>
            /// Целочисленное значение, хранимое в узле
            /// </summary>
            private int _value;

            public Operand(int value) => _value = value;

            public override int Evaluate() => _value;

            public override string ToString() => _value.ToString();
        }

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
            /// Ссылка на таблицу арифметических опереторов для данного дерева разбора
            /// </summary>
            private TableOfOperations _table;

            /// <summary>
            /// Левый сын текущего узда
            /// </summary>
            public Node _leftNode;

            /// <summary>
            /// Правый сын текущего узла
            /// </summary>
            public Node _rightNode;

            public Operator(string op, TableOfOperations table)
            {
                _operator = op;
                _table = table;
            }

            public override int Evaluate() => _table[_operator](_leftNode.Evaluate(), _rightNode.Evaluate());

            /// <summary>
            /// Представляет выражение в поддереве в инфиксной форме
            /// </summary>
            /// <returns>Строковое представление выражения</returns>
            public override string ToString() => $"({_leftNode} {_operator} {_rightNode})";
        }
    }
}