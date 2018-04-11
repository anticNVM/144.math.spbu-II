using System.Collections.Generic;

namespace ParseTreeSource
{
    public class ParseTree : IParseTree
    {
        private Node _root;

        public ParseTree(string expression)
        {
            var tokens = expression.Split(' ');
            var iter = GetEnumerator(tokens);
            BuildTree(_root, iter);
        }

        public int Evaluate() => _root.Evaluate();

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

        public IEnumerator<string> GetEnumerator(string[] tokens)
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