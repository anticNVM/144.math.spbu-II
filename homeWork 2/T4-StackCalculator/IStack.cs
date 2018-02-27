namespace T4_StackCalculator
{
    public interface IStack
    {
        void Push(int value);
        int? Pop();
        int? Peek();
        void Clear();
        bool IsEmpty();
        int Count { get; }
    }
}