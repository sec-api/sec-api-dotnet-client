namespace SecApi.Exception
{
    public class UnauthorizedSecApiException : SecApiException
    {
        public UnauthorizedSecApiException(string message) 
            : base(message)
        {
        }
    }
}