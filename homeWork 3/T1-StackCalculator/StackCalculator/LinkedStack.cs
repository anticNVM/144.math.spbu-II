using System;
using Exceptions;

namespace StackCalculator
{
    /// <summary>
    /// Класс, реализующий стек на остнове связного списка
    /// </summary>
    public class LinkedStack : IStack
    {
        /// <summary>
        /// Голова стека (ссылка на верхний элемент)
        /// </summary>
        private StackElement _head;

        public void Push(int value)
        {
            _head = new StackElement(value, _head);
            Count++;
        }

        public int Pop()
        {
            if (this.IsEmpty())
            {
                throw new EmptyStackException(
                    "Попытка доступа к элементам пустого стека"
                );
            }

            var tempValue = _head.Value;
            _head = _head.Next;
            Count--;
            return tempValue;
        }

        public int Peek()
        {
            if (this.IsEmpty())
            {
                throw new EmptyStackException(
                    "Попытка доступа к элементам пустого стека"
                );
            }

            return _head.Value;
        }

        public void Clear()
        {
            Count = 0;
            _head = null;
        }

        public int Count { get; private set; }                

        /// <summary>
        /// Класс, реализующий элемент стека, хранит целочисленные значения
        /// </summary>
        private class StackElement
        {
            public int Value { get; }
            public StackElement Next { get; }

            public StackElement(int value, StackElement next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}