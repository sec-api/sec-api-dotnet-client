namespace SecApi.Exception
{
    public class NotFoundSecApiException : SecApiException
    {
        public NotFoundSecApiException(string message) 
            : base(message)
        {
        }
    }
}