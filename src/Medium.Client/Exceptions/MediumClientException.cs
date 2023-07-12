using System;
using System.Runtime.Serialization;

namespace Medium.Client.Exceptions
{
    /// <summary>
    /// General exception for Medium Client.
    /// </summary>
    [Serializable]
    public class MediumClientException : Exception
    {
        public MediumClientException()
        {
        }

        public MediumClientException(string message) : base(message)
        {
        }

        public MediumClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MediumClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
