using System;

namespace Framework.CRUD.Exceptions
{
    public class UnsupportedTypeException : ClientException
    {
        public UnsupportedTypeException(string message) : base(message)
        {
        }

        public UnsupportedTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnsupportedTypeException(string message, string errorCode) : base(message, errorCode)
        {
        }
    }
}