using System;

namespace Behnammby.Phonebook.Data.Exceptions
{
    public class PhonebookException : ApplicationException
    {
        public PhonebookException() : base()
        {
        }

        public PhonebookException(string message) : base(message)
        {
        }

        public PhonebookException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}