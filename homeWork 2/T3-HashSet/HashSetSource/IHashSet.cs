namespace HashSetSource
{
    public interface IHashSet
    {
        void Add(int value);

        void Clear();

        bool Contains(int value);

        void Remove(int value);

        int Count { get; }

        float Factor { get; }
    }
}