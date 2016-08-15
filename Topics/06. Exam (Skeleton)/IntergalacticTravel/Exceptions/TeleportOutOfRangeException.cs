using System;
using System.Runtime.Serialization;

namespace IntergalacticTravel.Exceptions
{
    public class TeleportOutOfRangeException : ArgumentOutOfRangeException
    {
        public TeleportOutOfRangeException()
        {
        }

        public TeleportOutOfRangeException(string paramName) : base(paramName)
        {
        }

        public TeleportOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TeleportOutOfRangeException(string paramName, string message) : base(paramName, message)
        {
        }

        public TeleportOutOfRangeException(string paramName, object actualValue, string message) : base(paramName, actualValue, message)
        {
        }

        protected TeleportOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
