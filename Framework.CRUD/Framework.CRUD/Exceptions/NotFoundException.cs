using System;

namespace Framework.CRUD.Exceptions
{
    public class NotFoundException : ClientException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        public NotFoundException(string message, string errorCode) : base(message, errorCode)
        {
        }
    }
}