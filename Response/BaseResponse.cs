namespace RumahTuya.Response
{
    public abstract class BaseResponse
    {
        public string ToJsonString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
