using System;

namespace MusicRecommender.Common
{
    public class BearerToken
    {
        public string Value { get; }

        public BearerToken(string value)
        {
            ValidateToken(value);
            Value = value;
        }

        private void ValidateToken(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Token value cannot be null or empty.");
        }
    }
}
