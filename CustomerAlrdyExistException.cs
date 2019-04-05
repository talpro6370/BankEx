using System;
using System.Runtime.Serialization;

namespace Bank_ex
{
    [Serializable]
    internal class CustomerAlrdyExistException : Exception
    {
        public CustomerAlrdyExistException()
        {
        }

        public CustomerAlrdyExistException(string message) : base(message)
        {
        }

        public CustomerAlrdyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerAlrdyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}