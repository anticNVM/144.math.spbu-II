using System;
using Exceptions;

namespace StackCalculator
{
    /// <summary>
    /// Класс, реализующий стек на основе массива
    /// </summary>
    public class ArrayStack : IStack
    {
        /// <summary>
        /// Дефолтное значение размера стека
        /// </summary>
        private const int _defaultSize = 10;

        /// <summary>
        /// Размер массива под стек в данный момент
        /// </summary>
        private int _capacity;

        /// <summary>
        /// Индекс массива сразу за последним жлементом стека (свободная)
        /// </summary>
        private int _positionAfterTop;

        /// <summary>
        /// Стек
        /// </summary>
        private int[] _stack;

        public ArrayStack() : this(_defaultSize)
        {
        }

        public ArrayStack(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(size),
                    message: "Размер стека должен задаваться натуральным числом."
                );
            }

            _stack = new int[size];
            _capacity = size;
            _positionAfterTop = 0;
        }

        public void Push(int value)
        {
            _stack[_positionAfterTop] = value;
            _positionAfterTop++;

            if (_positionAfterTop >= _capacity)
            {
                this.Resize();
            }
        }

        public int Pop()
        {
            if (_positionAfterTop == 0)
            {
                throw new EmptyStackException(
                    "Попытка доступа к элементам пустого стека"
                );
            }

            return _stack[--_positionAfterTop];
        }

        public int Peek()
        {
            if (_positionAfterTop == 0)
            {
                throw new EmptyStackException(
                    "Попытка доступа к элементам пустого стека"
                );
            }
            
            return _stack[_positionAfterTop - 1];
        }

        public void Clear() => _positionAfterTop = 0;

        public int Count => _positionAfterTop;

        /// <summary>
        /// Увеличивает capacity стека вдвое (размер массива)
        /// </summary>
        private void Resize()
        {
            int factor = 2;
            _capacity *= factor;
            int[] newStack = new int[_capacity];
            _stack.CopyTo(newStack, 0);
            _stack = newStack;
        }
    }
}