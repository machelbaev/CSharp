using System;

namespace Task
{
    public class DataBaseException : Exception
    {
        public DataBaseException()
        {
        }

        public DataBaseException(string message) : base(message)
        {
        }
    }
}
