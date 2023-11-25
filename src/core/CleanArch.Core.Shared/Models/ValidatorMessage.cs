namespace CleanArch.Core.Shared.Models
{
    public class ValidatorMessage
    {
        public List<string> Errors { get; private set; }

        public ValidatorMessage(List<string> errors)
        {
            Errors = errors;
        }
    }
}
