﻿using System;

namespace UniqueListSource
{
    /// <summary>
    /// Бросается при попытке добваить в список уже существующий элемент.
    /// </summary>
    [Serializable]
    public class ValueAlreadyInListException : Exception
    {
        public ValueAlreadyInListException() { }

        public ValueAlreadyInListException(string message) : base(message) { }

        public ValueAlreadyInListException(string message, Exception inner)
            : base(message, inner) { }
    }
}
