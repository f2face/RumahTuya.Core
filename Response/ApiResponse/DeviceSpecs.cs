using Newtonsoft.Json;

namespace RumahTuya.Response
{
    public class DeviceSpecs : DeviceFunctions, IResult
    {
        [JsonProperty("status")]
        public Specs Status { get; set; }
    }
}
