namespace Source
{
    [System.Serializable]
    public class UnsupportedSymbolException : System.Exception
    {
        public UnsupportedSymbolException() { }
        public UnsupportedSymbolException(string message) : base(message) { }
        public UnsupportedSymbolException(string message, System.Exception inner) : base(message, inner) { }
        protected UnsupportedSymbolException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}