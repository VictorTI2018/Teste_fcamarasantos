namespace CleanArch.Core.Shared.Exceptions
{
    public class InfraException : Exception
    {
        public InfraException(string error) : base(error) { }
        public InfraException(Exception ex, string error = "Internal server error") : base(error, ex) { }
    }
}
