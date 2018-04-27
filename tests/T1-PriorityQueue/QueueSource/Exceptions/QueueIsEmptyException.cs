namespace QueueSource.Exceptions
{
    /// <summary>
    /// Бросается, если очередь пуста
    /// </summary>
    [System.Serializable]
    public class QueueIsEmptyException : System.Exception
    {
        public QueueIsEmptyException() { }
        public QueueIsEmptyException(string message) : base(message) { }
        public QueueIsEmptyException(string message, System.Exception inner) : base(message, inner) { }
        protected QueueIsEmptyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}