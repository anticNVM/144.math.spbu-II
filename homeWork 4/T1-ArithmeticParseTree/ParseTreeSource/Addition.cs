namespace ParseTreeSource
{
    public class Addition : Operator
    {
        public override char Op { get; } = '+';

        public override int Evaluate() => this._leftNode.Evaluate() + this._rightNode.Evaluate();
    }
}