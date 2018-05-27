namespace Source
{
    [System.Serializable]
    public class InvalidNumberOfDestinationsException : System.Exception
    {
        public InvalidNumberOfDestinationsException() { }
        public InvalidNumberOfDestinationsException(string message) : base(message) { }
        public InvalidNumberOfDestinationsException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidNumberOfDestinationsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}