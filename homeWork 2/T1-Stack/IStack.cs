namespace T1_Stack
{
    public interface IStack
    {
        void Push(int value);
        int Pop();
        int Peek();
        void Clear();
        //int Count {get;}
    }
}