using RestSharp;
using System;
using System.Threading.Tasks;

namespace MusicRecommender.Common.Service
{
    public class CustomHttpService : ICustomHttpService
    {
        private readonly RestClient _restClient;

        public CustomHttpService(Uri baseUri)
        {
            ValidateUri(baseUri);
            _restClient = new RestClient(baseUri);
        }

        public async Task<T> GetDataAsync<T>(Uri endpointUrl)
        {
            ValidateUri(endpointUrl);
            var request = new RestRequest(endpointUrl, Method.GET, DataFormat.Json);

            return await _restClient.GetAsync<T>(request);
        }

        private void ValidateUri(Uri uri)
        {
            if (uri == null || string.IsNullOrEmpty(uri.OriginalString))
                throw new ArgumentException("The uri cannot be null or empty.");
        }
    }
}
