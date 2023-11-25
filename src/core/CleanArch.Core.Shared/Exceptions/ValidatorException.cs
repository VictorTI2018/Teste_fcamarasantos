namespace CleanArch.Core.Shared.Exceptions
{
    public class ValidatorException : Exception
    {
        public List<string> ErrorsMessage { get; set; } = new();

        public ValidatorException(List<string> errorsMessage)
        {
            ErrorsMessage = errorsMessage;
        }
    }
}
