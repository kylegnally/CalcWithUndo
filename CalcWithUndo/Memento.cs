namespace CalcWithUndo
{
    /// <summary>
    /// Class to provide a Memento for use in the Memento pattern.
    /// </summary>
    class Memento : IMemento
    {
        private string _state;
        
        /// <summary>
        /// Constructor for the Memento.
        /// </summary>
        /// <param name="state"></param>
        public Memento(string state)
        {
            _state = state;
        }

        /// <summary>
        /// Gets the state of the Memento.
        /// </summary>
        /// <returns>string</returns>
        public string GetState()
        {
            return _state;
        }
    }
}
