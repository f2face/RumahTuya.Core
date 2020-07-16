namespace RumahTuya.Response
{
#pragma warning disable IDE1006 // Naming Styles
    public class ApiResponse<IResult> : BaseResponse
    {
        public bool success { get; set; }
        public long t { get; set; }
        public IResult result { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
    }
}
