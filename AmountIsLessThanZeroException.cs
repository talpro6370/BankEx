using System;
using System.Runtime.Serialization;

namespace Bank_ex
{
    [Serializable]
    internal class AmountIsLessThanZeroException : ApplicationException
    {
        public AmountIsLessThanZeroException()
        {
          
        }

        public AmountIsLessThanZeroException(string message) : base(message)
        {
        }

        public AmountIsLessThanZeroException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AmountIsLessThanZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}