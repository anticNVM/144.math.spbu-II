namespace Source
{
    /// <summary>
    /// Исключение, бросаемое при неверном числе аватаров игроков на карте
    /// </summary>
    [System.Serializable]
    public class InvalidNumberOfAvatarsException : System.Exception
    {
        public InvalidNumberOfAvatarsException() { }
        public InvalidNumberOfAvatarsException(string message) : base(message) { }
        public InvalidNumberOfAvatarsException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidNumberOfAvatarsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}