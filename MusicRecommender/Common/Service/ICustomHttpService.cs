using System;
using System.Threading.Tasks;

namespace MusicRecommender.Common.Service
{
    public interface ICustomHttpService
    {
        public Task<T> GetDataAsync<T>(Uri url);
    }
}
