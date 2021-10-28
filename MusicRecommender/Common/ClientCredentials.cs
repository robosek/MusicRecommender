using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommender.Common
{
    public class ClientCredentials
    {
        public string ClientId { get; }
        public string ClientSecret { get; }

        public ClientCredentials(string clientId, string clientSecret)
        {
            Validate(clientId);
            Validate(clientSecret);
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Client ID and Secret value cannot be empty or null.");
        }
        
        public string GetClientCredentialsBase64()
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}");
            return Convert.ToBase64String(plainTextBytes);
        }
    }

}
