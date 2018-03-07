using System;

namespace UList
{
    public class UniqueList : LinkedList.LinkedList
    {
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
