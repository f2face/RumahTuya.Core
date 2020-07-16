namespace RumahTuya.Request
{
    public class RequestSignature
    {
        public readonly string Signature;
        public readonly long Timestamp;

        public RequestSignature(string signature, long timestamp)
        {
            Signature = signature;
            Timestamp = timestamp;
        }
    }
}
