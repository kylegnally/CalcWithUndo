namespace CalcWithUndo
{
    class Caretaker
    {
        private static GenericStack<IMemento> _mementoStack;
        private static Caretaker _instanceCaretaker;

        private Caretaker() { }

        public static Caretaker GetInstance()
        {
            if (_instanceCaretaker == null)
            {
                _instanceCaretaker = new Caretaker();
                _mementoStack = new GenericStack<IMemento>();
            }
            return _instanceCaretaker;
        }

        public void Add(IMemento memento)
        {
            _mementoStack.Push(memento);
        }

        public IMemento Undo()
        {
            return _mementoStack.Pop();
        }

        public IMemento Peek()
        {
            return _mementoStack.Peek();
        }

        public void Reset()
        {
            _mementoStack = new GenericStack<IMemento>();
            _instanceCaretaker = null;
        }
    }
}
