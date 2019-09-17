using System;

namespace Framework.CRUD.Exceptions
{
    public class ClientException : Exception
    {
        public string ErrorCode { get; set; }
        
        public ClientException(string message) : base(message)
        {
            
        }

        public ClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        public ClientException(string message, string errorCode, Exception innerException = null) : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }
    }
}