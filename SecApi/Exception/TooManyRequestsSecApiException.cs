namespace SecApi.Exception
{
    public class TooManyRequestsSecApiException : SecApiException
    {
        public TooManyRequestsSecApiException(string message) 
            : base(message)
        {
        }
    }
}