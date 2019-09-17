using System;

namespace Framework.CRUD.Exceptions
{
    public class ConflictException : ClientException
    {
        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        public ConflictException(string message, string errorCode) : base(message, errorCode)
        {
        }
    }
}