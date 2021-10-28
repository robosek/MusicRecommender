using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommender.Common
{
    public class Url
    {
        public Uri BaseUrl { get; }
        public Uri EndpointUrl { get; }

        public Url(string baseUrl, string endpointUrl)
        {
            Validate(baseUrl);
            Validate(endpointUrl);
            BaseUrl = new Uri(baseUrl);
            EndpointUrl = new Uri(endpointUrl);
        }

        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Provided baseUrl and endpointUrl cannot be null or empty.");
        }
    }
}
