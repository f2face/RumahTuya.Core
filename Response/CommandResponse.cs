namespace RumahTuya.Response
{
#pragma warning disable IDE1006 // Naming Styles
    public class CommandResponse : BaseResponse
    {
        public bool success { get; set; }
        public bool result { get; set; }
        public long t { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
    }
}
