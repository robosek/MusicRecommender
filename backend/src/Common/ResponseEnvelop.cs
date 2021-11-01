namespace MusicRecommender.Common
{
    public class ResponseEnvelop<T>
    {
        public int StatusCode { get; }
        public string Message { get; }
        public T Result { get; }

        public ResponseEnvelop(int statusCode, string message, T result)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }
    }
}
