namespace T2_LinkedList
{
    public interface ILinkedList
    {
        // добавляет элемент в конец списка
        void Append(int value);
        void AddToBegin(int value);
        bool Insert(int value, int after);
        bool Remove(int value);
        bool Contains(int value);
        void Clear();
        bool IsEmpty();
        LinkedList GetCopy();
        int GetFirst();
        LinkedList GetTail();
        int Count { get; }
    }
}