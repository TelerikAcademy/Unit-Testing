using System;
using System.Runtime.Serialization;

namespace IntergalacticTravel.Exceptions
{
    public class InvalidTeleportationLocationException : Exception
    {
        public InvalidTeleportationLocationException()
        {
        }

        public InvalidTeleportationLocationException(string message) : base(message)
        {
        }

        public InvalidTeleportationLocationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTeleportationLocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
