using System;
using System.Runtime.Serialization;

namespace RumahTuya.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base()
        {
        }
        
        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
