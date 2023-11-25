namespace CleanArch.Core.Shared.Models
{
    public class InfraMessage
    {
        public string MessageException { get; set; }

        public string Error { get; set; }

        public InfraMessage(string messageException, string error = "Internal server error.")
        {
            MessageException = messageException;
            Error = error;
        }
    }
}
