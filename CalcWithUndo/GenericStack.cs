namespace CalcWithUndo
{
    /// <summary>
    /// This class contains an implementation of a generic stack in the style of a linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericStack<T> : IGenericStack<T>
    {
        /// <summary>
        /// A Node in the linked list.
        /// </summary>
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        // vars for our list
        protected Node head;
        protected int size = 0;

        // flag for an empty list
        public bool isEmpty
        {
            get { return head == null; }
        }

        public int Size
        {
            get { return size; }
        }

        /// <summary>
        /// Pushes a Node onto the stack.
        /// </summary>
        /// <param name="Data"></param>
        public void Push(T Data)
        {
            Node oldHead = head;
            head = new Node();
            head.Data = Data;
            head.Next = oldHead;
            size++;
        }

        /// <summary>
        /// Pops a Node from the stack, returning its data.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Looks at a node and returns its data, but leaves the node in the list.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            T returnData;
            returnData = head.Data;
            return returnData;
        }
    }
}
