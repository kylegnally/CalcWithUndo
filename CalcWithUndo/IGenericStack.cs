namespace CalcWithUndo
{
    interface IGenericStack<T>
    {
        void Push(T Data);
        T Pop();

        bool isEmpty { get; }
        int Size { get; }
    }
}