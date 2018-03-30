using System;

namespace ListSource
{
    /// <summary>
    /// Исключение, бросаемое при попытке удалить несуществующий элемент из списка
    /// </summary>
    [Serializable]
    public class ItemIsNotInListException : Exception
    {
        public ItemIsNotInListException() { }

        public ItemIsNotInListException(string message) : base(message) { }

        public ItemIsNotInListException(string message, Exception inner)
            : base(message, inner) { }
    }
}