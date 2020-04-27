using System.Runtime.Serialization;

namespace SecApi.Exception
{
    public abstract class SecApiException : System.Exception
    {
        protected SecApiException()
        {
        }

        protected SecApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected SecApiException(string message) : base(message)
        {
        }

        protected SecApiException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}