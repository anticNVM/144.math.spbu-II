using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, бросаемое при попытке доступа к элементам пустого стека
    /// </summary>
    [Serializable]
    public class EmptyStackException : Exception
    {
        public EmptyStackException() { }
        
        public EmptyStackException(string message) : base(message) { }

        public EmptyStackException(string message, Exception inner)
           : base(message, inner) { }
    }
}
