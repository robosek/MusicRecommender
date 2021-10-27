using System;

namespace MusicRecommender.Common
{
    public class ConvertToJsonException<T> : Exception
    {
        public ConvertToJsonException(string json, string exceptionMessage)
            : base($"Cannot convert type {nameof(T)} to json {json}." +
                  $"Exception occured: {exceptionMessage} ")
        {
        }
    }
}
