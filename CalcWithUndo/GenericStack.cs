using System;

namespace CalcWithUndo
{
    class GenericStack<T> : IGenericStack<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node head;
        protected int size = 0;

        public bool isEmpty
        {
            get { return head == null; }
        }

        public int Size
        {
            get { return size; }
        }

        public void Push(T Data)
        {
            Node oldHead = head;
            head = new Node();
            head.Data = Data;
            head.Next = oldHead;
            size++;
        }

        public T Pop()
        {
            T returnData;

            if (isEmpty)
            {
                returnData = default;
                return returnData;
            }
            returnData = head.Data;
            head = head.Next;
            size--;
            return returnData;
        }

        public T Peek()
        {
            T returnData;
            returnData = head.Data;
            return returnData;
        }
    }
}
