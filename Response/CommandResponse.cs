using Newtonsoft.Json;

namespace RumahTuya.Response
{
    public class CommandResponse : ApiResponse<bool>
    {
        [JsonProperty("result")]
        public override bool Result { get; set; }
    }
}
