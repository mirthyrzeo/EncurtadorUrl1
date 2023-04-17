using EncurtadorUrl.Repositories;
using System.Threading.Tasks;

namespace EncurtadorUrl.Services
{
    public interface IUrlShortenerService
    {
        Task<string> ShortenUrlAsync(string longUrl);
    }
}

namespace EncurtadorUrl.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly IUrlRepository _urlRepository;

        public Task<string> ShortenUrlAsync(string longUrl)
        {
            throw new NotImplementedException();
        }
    }
}



