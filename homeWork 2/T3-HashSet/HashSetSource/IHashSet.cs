namespace HashSetSource
{
    public interface IHashSet
    {
        void Add(int value);

        void Clear();

        bool Contains();

        void Remove(int value);

        int Count { get; }
    }
}