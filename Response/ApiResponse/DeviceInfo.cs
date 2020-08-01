using Newtonsoft.Json;

namespace RumahTuya.Response
{
    public class DeviceInfo : IResult
    {
        [JsonProperty("active_time")]
        public int ActiveTime { get; set; }

        [JsonProperty("biz_type")]
        public int BizType { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("create_time")]
        public int CreatedAt { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ip")]
        public string IPAddress { get; set; }

        [JsonProperty("online")]
        public bool IsOnline { get; set; }

        [JsonProperty("local_key")]
        public string LocalKey { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("status")]
        public Attributes Status { get; set; }

        [JsonProperty("sub")]
        public bool Sub { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("uid")]
        public string UID { get; set; }

        [JsonProperty("update_time")]
        public int UpdatedAt { get; set; }

        [JsonProperty("uuid")]
        public string UUID { get; set; }
    }
}
