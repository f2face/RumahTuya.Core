using Newtonsoft.Json;

namespace RumahTuya.Request
{
    public struct RequestSignature
    {
        [JsonProperty("sign")]
        public string Signature { get; set; }

        [JsonProperty("t")]
        public long Timestamp { get; set; }

        public RequestSignature(string signature, long timestamp)
        {
            Signature = signature;
            Timestamp = timestamp;
        }
    }
}
