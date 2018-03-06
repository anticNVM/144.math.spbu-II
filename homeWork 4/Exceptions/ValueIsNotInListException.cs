using System;

namespace Exceptions
{
    [Serializable]
    public class ValueIsNotInListException : Exception
    {
        public ValueIsNotInListException() { }

        public ValueIsNotInListException(string message) : base(message) { }

        public ValueIsNotInListException(string message, Exception inner)
            : base(message, inner) { }
    }
}