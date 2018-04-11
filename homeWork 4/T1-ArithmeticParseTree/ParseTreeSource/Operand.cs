namespace ParseTreeSource
{
    public class Operand : Node
    {
        private int _value;

        public Operand(int value) => _value = value;

        public override int Evaluate() => _value;

        public override string ToString() => _value.ToString();
    }
}