namespace SecApi.Exception
{
    public class BadRequestSecApiException : SecApiException
    {
        public BadRequestSecApiException(string message) 
            : base(message)
        {
        }
    }
}