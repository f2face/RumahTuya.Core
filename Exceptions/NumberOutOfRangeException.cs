using System;
using System.Runtime.Serialization;

namespace RumahTuya.Exceptions
{
    public class NumberOutOfRangeException : Exception
    {
        public NumberOutOfRangeException() : base()
        {
        }

        public NumberOutOfRangeException(string message) : base(message)
        {
        }

        public NumberOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NumberOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
