using RestSharp;
using System.Threading.Tasks;

namespace MusicRecommender.Common.Service
{
    public class CustomHttpService : ICustomHttpService
    {
        public async Task<T> GetDataAsync<T>(Url url, BearerToken token)
        {
            RestClient restClient = new RestClient(url.BaseUrl);
            var request = new RestRequest(url.EndpointUrl, Method.GET, DataFormat.Json);
            request.AddHeader("Authorization", $"Bearer {token.Value}");

            return await restClient.GetAsync<T>(request);
        }

        public async Task<T> ClientCredentialsToken<T>(Url url, ClientCredentials credentials)
        {
            RestClient restClient = new RestClient(url.BaseUrl);
            var request = new RestRequest(url.EndpointUrl, Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", $"Basic {credentials.GetClientCredentialsBase64()}");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials", ParameterType.RequestBody);

            return await restClient.PostAsync<T>(request);
        }  
    }
}
