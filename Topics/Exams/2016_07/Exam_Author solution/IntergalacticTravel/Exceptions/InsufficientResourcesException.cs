using System;
using System.Runtime.Serialization;

namespace IntergalacticTravel.Exceptions
{
    public class InsufficientResourcesException : Exception
    {
        public InsufficientResourcesException()
        {
        }

        public InsufficientResourcesException(string message) : base(message)
        {
        }

        public InsufficientResourcesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientResourcesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
