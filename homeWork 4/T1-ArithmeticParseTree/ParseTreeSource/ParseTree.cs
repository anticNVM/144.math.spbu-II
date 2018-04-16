using System.Collections.Generic;
using System;

namespace ParseTreeSource
{
    public partial class ParseTree : IParseTree
    {
        private Node _root;

        private sealed class MapOfOperations : Dictionary<string, Func<int, int, int>> { }
        private MapOfOperations _operations = new MapOfOperations{
            {"+", (x, y) => x + y},
            {"-", (x, y) => x - y},
            {"*", (x, y) => x * y},
            {"/", (x, y) => x / y},
        };

        public ParseTree() { }

        public ParseTree(string expression)
        {
            var tokens = expression.Split(' ');
            var iter = GetEnumerator(tokens);
            BuildTree(ref _root, iter);
        }

        public int Evaluate() => _root.Evaluate();

        public override string ToString() => _root.ToString();

        public void AddOperation(string op, Func<int, int, int> operation) => _operations.Add(op, operation);

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
                node = new Operator(iter.GetNext());
                BuildTree(ref node._leftNode, iter);
                BuildTree(ref node._rightNode, iter);
            }
            // тогда это число
            else if (int.TryParse(current, out int value))
            {
                node = new Operand(value);
            }
        }

        private IEnumerator<string> GetEnumerator(string[] tokens)
        {
            foreach (var token in tokens)
            {
                yield return token;
            }
        }
    }

    public static class EnumeratorExtension
    {
        public static string GetNext(this IEnumerator<string> iter)
        {
            return iter.MoveNext() ? iter.Current : null;
        }
    }
}