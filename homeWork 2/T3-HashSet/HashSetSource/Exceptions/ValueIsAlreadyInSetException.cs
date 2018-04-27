namespace HashSetSource
{
    /// <summary>
    /// Бросается при попытке добавить в множество уже существующее значение
    /// </summary>
    [System.Serializable]
    public class ValueIsAlreadyInSetException : System.Exception
    {
        public ValueIsAlreadyInSetException() { }
        public ValueIsAlreadyInSetException(string message) : base(message) { }
        public ValueIsAlreadyInSetException(string message, System.Exception inner) : base(message, inner) { }
        protected ValueIsAlreadyInSetException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}