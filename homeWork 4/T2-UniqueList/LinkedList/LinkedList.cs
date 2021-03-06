﻿using System;

namespace LinkedList
{
    public class LinkedList : ILinkedList
    {
        /// <summary>
        /// Узел списка
        /// </summary>
        protected class Node
        {
            public int Value { get; }
            public Node Next { get; set; }

            public Node(int value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node head;
        private Node tail;
        public int Count { get; private set; }

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
                    current = current.Next;
                }

                return current.Value;
            }
        }

        public virtual void Append(int value)
        {
            var newNode = new Node(value, null);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public virtual void AddToBegin(int value)
        {
            if (head == null)
            {
                this.Append(value);
            }
            else
            {
                head = new Node(value, head);
            }

            Count++;
        }

        public virtual void Insert(int value, int after)
        {
            if (after < 0 || after >= Count)
            {
                throw new IndexOutOfRangeException("Выход за границы списка");
            }

            if (after == (Count - 1))
            {
                this.Append(value);
            }
            else
            {
                Node current = head;
                int currentIndex = 0;

                while (currentIndex != after)
                {
                    current = current.Next;
                    currentIndex++;
                }

                current.Next = new Node(value, current.Next);
                Count++;
            }
        }

        public void Remove(int value)
        {
            Node previous = null;
            Node current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    // если в начале списка
                    if (previous == null)
                    {
                        head = current.Next;
                        // если единственный элемент списка
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        // если в конце списка
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }

                    Count--;
                    return;
                }

                previous = current;
                current = current.Next;
            }

            throw new Exceptions.ValueIsNotInListException(
                String.Format($"Значения параметра {nameof(value)} не существует в списке")
            );
        }

        public bool Contains(int value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool IsEmpty() => Count == 0;

        public ILinkedList Copy()
        {
            var copyList = new LinkedList();
            Node current = head;

            while (current != null)
            {
                copyList.Append(current.Value);
                current = current.Next;
            }

            return copyList;
        }

        public int GetHead() => head != null ? head.Value : default(int);
        
        public ILinkedList GetTail()
        {
            var tailList = this.Copy() as LinkedList;
            if (!tailList.IsEmpty())
            {
                tailList.head = head.Next;
                tailList.Count--;
            }

            return tailList;
        }

        public override string ToString()
        {
            string list = "[";

            Node current = head;
            while (current != null)
            {
                list += $"{current.Value}, ";
                current = current.Next;
            }

            list += "]";
            return list;
        }
    }
}