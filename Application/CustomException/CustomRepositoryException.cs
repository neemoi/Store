namespace Application.CustomException
{
    public class CustomRepositoryException : Exception
    {
        public string? ErrorCode { get; }

        public string? AdditionalInfo { get; }

        public CustomRepositoryException(string message, string errorCode, string additionalInfo = "") : base(message)
        {
            ErrorCode = errorCode;
            AdditionalInfo = additionalInfo;
        }
    }
}
