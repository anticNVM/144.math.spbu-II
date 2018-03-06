using System;

namespace UniqueList
{
    public class UniqueList : LinkedList.LinkedList
    {
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Выход за границы списка");
                }

                var current = head;
                for (var _ = 0; _ < index; ++_)
                {
                    current = head.Next;
                }

                return current.Value;
            }
        }

        new public void Append(int value)
        {
            if (this.Contains(value))
            {
                throw new Exceptions.ValueAlreadyInListException(
                    String.Format($"Значение параметра {nameof(value)} уже существует в списке")
                );
            }

            base.Append(value);
        }

        new public void AddToBegin(int value)
        {
            if (this.Contains(value))
            {
                throw new Exceptions.ValueAlreadyInListException(
                    String.Format($"Значение параметра {nameof(value)} уже существует в списке")
                );
            }

            base.AddToBegin(value);
        }

        new public void Insert(int value, int after)
        {
            if (this.Contains(value))
            {
                throw new Exceptions.ValueAlreadyInListException(
                    String.Format($"Значение параметра {nameof(value)} уже существует в списке")
                );
            }

            base.Insert(value, after);
        }
    }
}
