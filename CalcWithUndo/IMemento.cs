namespace CalcWithUndo
{
    /// <summary>
    /// Memento interface.
    /// </summary>
    public interface IMemento
    {
        string GetState();
        //string GetResult();

        //string GetEquation();
        //string GetRunningTotal();
    }
}
