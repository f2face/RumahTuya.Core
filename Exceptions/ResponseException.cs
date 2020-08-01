using System;

namespace RumahTuya.Exceptions
{
    class ResponseException : Exception
    {
        public int Code { get; }

        public ResponseException(string message, int code) : base(message)
        {
            Code = code;
        }

        public ResponseException(string message, int code, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }
    }
}
