using System;

namespace Exceptions
{
    [Serializable]
    public class ValueAlreadyInListException : Exception
    {
        public ValueAlreadyInListException() { }

        public ValueAlreadyInListException(string message) : base(message) { }

        public ValueAlreadyInListException(string message, Exception inner)
            : base(message, inner) { }
    }
}
