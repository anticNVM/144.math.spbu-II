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

        public ParseTree(string expression)
        {
            var tokens = expression.Split(' ');
            var iter = GetEnumerator(tokens);
            BuildTree(_root, iter);
        }

        public int Evaluate() => _root.Evaluate();

        public override string ToString() => _root.ToString();

        private void BuildTree(Node node, IEnumerator<string> iter)
        {
            var current = iter.GetNext();
            // тогда след за ним это оператор
            if (current == "(")
            {
                node = new Operator(iter.GetNext());
                BuildTree(node.LeftNode, iter);
                BuildTree(node.RightNode, iter);
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