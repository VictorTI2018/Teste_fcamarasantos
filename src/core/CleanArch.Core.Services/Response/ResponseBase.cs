namespace CleanArch.Core.Services.Response
{
    public abstract class ResponseBase
    {
        public List<string> Message { get;  set; }

        public object? Data { get; set; }

        public bool Status { get; set; }
    }
}
