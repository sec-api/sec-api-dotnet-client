namespace SecApi.Exception
{
    public class UnknownSecApiException : SecApiException
    {
        public UnknownSecApiException(string message) 
            : base(message)
        {
        }
    }
}