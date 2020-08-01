using Newtonsoft.Json;
using System.Collections.Generic;

namespace RumahTuya.Response
{
    public struct Spec
    {
        [JsonProperty("code")]
        public string Key { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("values")]
        public string Values { get; set; }
    }

    public class Specs : List<Spec>
    {
        public Spec GetSpec(string specKey)
        {
            return Find(attr => attr.Key.Equals(specKey));
        }
    }
}
