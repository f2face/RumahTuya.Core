using Newtonsoft.Json;

namespace RumahTuya.Response
{
    public class ApiResponse<IResult> : BaseResponse
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("code")]
        public int ResponseCode { get; set; }

        [JsonProperty("msg")]
        public string ResponseMessage { get; set; }

        [JsonProperty("result")]
        public virtual IResult Result { get; set; }

        [JsonProperty("t")]
        public long Timestamp { get; set; }
    }
}
