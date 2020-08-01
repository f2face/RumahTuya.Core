using Newtonsoft.Json;
using System.Collections.Generic;

namespace RumahTuya.Response
{
    public struct Attribute
    {
        [JsonProperty("code")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Attributes : List<Attribute>, IResult
    {
        public string GetAttribute(string key)
        {
            return Find(attr => attr.Key.Equals(key)).Value;
        }
    }
}
