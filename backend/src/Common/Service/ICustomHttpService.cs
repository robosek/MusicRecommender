using System.Threading.Tasks;

namespace MusicRecommender.Common.Service
{
    public interface ICustomHttpService
    {
        public Task<T> GetDataAsync<T>(Url url, BearerToken token);

        public Task<T> ClientCredentialsToken<T>(Url url, ClientCredentials credentials);
    }
}
