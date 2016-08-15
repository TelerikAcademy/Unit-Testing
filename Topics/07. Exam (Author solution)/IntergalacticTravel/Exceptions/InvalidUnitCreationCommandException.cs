using System;
using System.Runtime.Serialization;

namespace IntergalacticTravel.Exceptions
{
    public class InvalidUnitCreationCommandException : Exception
    {
        public InvalidUnitCreationCommandException()
        {
        }

        public InvalidUnitCreationCommandException(string message) : base(message)
        {
        }

        public InvalidUnitCreationCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidUnitCreationCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
