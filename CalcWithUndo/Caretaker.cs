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

        private Calculator _calculator = null;

        private Caretaker() { }
        private static Caretaker _instanceCaretaker;

        public static Caretaker GetInstance(Calculator calc)
        {
            if (_instanceCaretaker == null)
            {
                _instanceCaretaker = new Caretaker(calc);
                _mementoStack = new GenericStack<IMemento>();
            }
            _mementoStack.Push(calc.State);
            return _instanceCaretaker;
        }

        public Caretaker(Calculator calc)
        {
            _calculator = calc;
        }

        public IMemento Undo()
        {
            return _mementoStack.Pop();
        }

    }
}
