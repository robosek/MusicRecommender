using System;

namespace MusicRecommender.Common
{
    public class ConvertFromJsonException<T> : Exception
    {
        public ConvertFromJsonException(string json, string exceptionMessage)
            : base($"Cannot convert json {json} to type {nameof(T)}." +
                  $"Exception occured: {exceptionMessage} ")
        {
        }
    }
}
