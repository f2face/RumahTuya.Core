using Newtonsoft.Json;

namespace RumahTuya.Response
{
    public class Credentials : BaseResponse, IResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expire_time")]
        public int ExpireTime { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("uid")]
        public string UID { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
