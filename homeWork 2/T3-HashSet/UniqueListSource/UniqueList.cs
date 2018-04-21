using System;
using LinkedListSource;

namespace UniqueListSource
{
    /// <summary>
    /// Связный список, не содержащий повторяющихся элементов
    /// </summary>
    public class UniqueList : List
    {
        public override void Append(int value)
        {
            if (this.Contains(value))
            {
                throw new ValueAlreadyInListException(
                    String.Format($"Значение параметра {nameof(value)} уже существует в списке")
                );
            }

            base.Append(value);
        }

        public override void AddToBegin(int value)
        {
            if (this.Contains(value))
            {
                throw new ValueAlreadyInListException(
                    String.Format($"Значение параметра {nameof(value)} уже существует в списке")
                );
            }

            base.AddToBegin(value);
        }

        public override void Insert(int value, int after)
        {
            if (this.Contains(value))
            {
                throw new ValueAlreadyInListException(
                    String.Format($"Значение параметра {nameof(value)} уже существует в списке")
                );
            }

            base.Insert(value, after);
        }
    }
}
