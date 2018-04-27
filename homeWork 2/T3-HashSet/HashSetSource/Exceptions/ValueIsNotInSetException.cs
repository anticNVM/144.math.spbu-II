namespace HashSetSource
{
    /// <summary>
    /// Бросается при попытке получить несуществующее значение из множества
    /// </summary>
    [System.Serializable]
    public class ValueIsNotInSetException : System.Exception
    {
        public ValueIsNotInSetException() { }
        public ValueIsNotInSetException(string message) : base(message) { }
        public ValueIsNotInSetException(string message, System.Exception inner) : base(message, inner) { }
        protected ValueIsNotInSetException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}