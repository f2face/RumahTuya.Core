namespace RumahTuya.Request
{
#pragma warning disable IDE1006 // Naming Styles
    public class Command
    {
        public string code { get; set; }
        public object value { get; set; }

        public Command(string code, object value)
        {
            this.code = code;
            this.value = value;
        }
    }
}
