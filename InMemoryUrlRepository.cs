using CSharpVitamins;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncurtadorUrl.Repositories
{
    public class InMemoryUrlRepository : IUrlRepository
    {
        private readonly IDictionary<string, string> _urlDatabase;

        public InMemoryUrlRepository()
        {
            _urlDatabase = new Dictionary<string, string>();
        }

        public Task<string> GetLongUrlAsync(string shortUrl)
        {
            return Task.FromResult(_urlDatabase.TryGetValue(shortUrl, out string longUrl) ? longUrl : null);
        }

        public async Task<string> SaveUrlAsync(string longUrl)
        {
            var shortUrl = await Task.Run(() => ShortGuid.NewGuid().ToString());
            _urlDatabase.Add(shortUrl, longUrl);
            return shortUrl;
        }
    }
}
