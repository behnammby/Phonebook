using System;

namespace Behnammby.Phonebook.Data.Exceptions
{
    public class PaginationException : PhonebookException
    {
        public PaginationException() : base()
        {
        }

        public PaginationException(string message) : base(message)
        {
        }

        public PaginationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}