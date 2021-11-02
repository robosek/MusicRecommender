using System;

namespace MusicRecommender.Common
{
    public class BearerToken
    {
        public string Value { get; }
        public DateTime ExpiresIn { get; }

        private const int OFFSET_TIME_SECONDS = 60;

        public BearerToken(string value, int expiresIn)
        {
            ValidateToken(value);
            Value = value;
            ExpiresIn = DateTime.Now.AddSeconds(expiresIn - OFFSET_TIME_SECONDS);
        }

        private void ValidateToken(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Token value cannot be null or empty.");
        }
    }
}
