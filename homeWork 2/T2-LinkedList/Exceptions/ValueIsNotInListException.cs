using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, бросаемое при попытке удалить несуществующий элемент из списка
    /// </summary>
    [Serializable]
    public class ValueIsNotInListException : Exception
    {
        public ValueIsNotInListException() { }

        public ValueIsNotInListException(string message) : base(message) { }

        public ValueIsNotInListException(string message, Exception inner)
            : base(message, inner) { }
    }
}
