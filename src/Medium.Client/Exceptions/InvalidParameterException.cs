using System;
using System.Runtime.Serialization;

namespace Medium.Client.Exceptions
{
    /// <summary>
    /// Exception for invalid parameters.
    /// </summary>
    [Serializable]
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException()
        {
        }

        public InvalidParameterException(string message) : base(message)
        {
        }

        public InvalidParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
