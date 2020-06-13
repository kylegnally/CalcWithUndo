namespace CalcWithUndo
{
    class Caretaker
    {
        private static GenericStack<IMemento> _mementoStack;
        private static Caretaker _instanceCaretaker;

        /// <summary>
        /// Empty private constructor.
        /// </summary>
        private Caretaker() { }

        /// <summary>
        /// Singleton. Gets an instannce of the Caretaker and its stack.
        /// </summary>
        /// <returns></returns>
        public static Caretaker GetInstance()
        {
            if (_instanceCaretaker == null)
            {
                _instanceCaretaker = new Caretaker();
                _mementoStack = new GenericStack<IMemento>();
            }
            return _instanceCaretaker;
        }

        /// <summary>
        /// Add method to put a Memento onto the stack.
        /// </summary>
        /// <param name="memento"></param>
        public void Add(IMemento memento)
        {
            _mementoStack.Push(memento);
        }

        /// <summary>
        /// Pops a Memento off the stack.
        /// </summary>
        /// <returns>IMemento</returns>
        public IMemento Undo()
        {
            return _mementoStack.Pop();
        }

        /// <summary>
        /// Looks at the top item on the stack. unimplemented.
        /// </summary>
        /// <returns>IMemento</returns>
        public IMemento Peek()
        {
            return _mementoStack.Peek();
        }

        /// <summary>
        /// Reset method. Creates a new stack and nullifies the caretaker instance.
        /// </summary>
        public void Reset()
        {
            _mementoStack = new GenericStack<IMemento>();
            _instanceCaretaker = null;
        }
    }
}
