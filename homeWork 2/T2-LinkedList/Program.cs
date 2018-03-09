using System;

namespace T2_LinkedList
{
    class Program
    {
        private static void Main(string[] args)
        {
            ListTest();
        }

        private static void ListTest()
        {
            var list = new LinkedList();

            GetListStatus(list);
            list.Append(1);
            GetListStatus(list);
            list.AddToBegin(2);
            GetListStatus(list);
            list.Insert(3, 0);
            GetListStatus(list);
            list.Remove(2);
            GetListStatus(list);
            Console.WriteLine(list.Contains(3));
            GetListStatus(list);
            list.Clear();
            GetListStatus(list);
            Console.WriteLine(list.IsEmpty());
            GetListStatus(list);

            var copy = list.Copy();
            Console.WriteLine(copy.GetHead());
            list.Append(1);
            list.Append(2);
            Console.WriteLine(list.GetTail());
        }

        private static void GetListStatus(LinkedList list)
        {
            Console.WriteLine($"{list.Count}: {list.ToString()}");
        }
    }
}
