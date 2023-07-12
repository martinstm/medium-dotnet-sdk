using System;
using System.Runtime.Serialization;

namespace Medium.Client.Exceptions
{
    /// <summary>
    /// Exception for missing required configurations.
    /// </summary>
    [Serializable]
    public class MissingConfigurationException : Exception
    {
        public MissingConfigurationException()
        {
        }

        public MissingConfigurationException(string message) : base(message)
        {
        }

        public MissingConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
