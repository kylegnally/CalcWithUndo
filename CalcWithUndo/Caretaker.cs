using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    class Caretaker
    {
        private static GenericStack<IMemento> _mementoStack;

        private Caretaker() { }
        private static Caretaker _instanceCaretaker;

        public static Caretaker GetInstance()
        {
            if (_instanceCaretaker == null)
            {
                _instanceCaretaker = new Caretaker();
                _mementoStack = new GenericStack<IMemento>();
            }
            return _instanceCaretaker;
        }

        // add method for caretaker
        public void Add(IMemento memento)
        {
            _mementoStack.Push(memento);
        }

        // Get method for the caretaker
        public IMemento Undo()
        {
            return _mementoStack.Pop();
        }
    }
}
