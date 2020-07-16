namespace RumahTuya.Response
{
#pragma warning disable IDE1006 // Naming Styles
    public class Credentials : BaseResponse, IResult
    {
        public string access_token { get; set; }
        public int expire_time { get; set; }
        public string refresh_token { get; set; }
        public string uid { get; set; }
        public long timestamp { get; set; }
    }
}
