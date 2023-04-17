using System.Threading.Tasks;
using Encurtador.Core.Interfaces;
using Encurtador.Core.Models;
using Encurtador.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Encurtador.Infrastructure.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlDbContext _context;

        public UrlRepository(UrlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();
        }

        public async Task<Url> GetByShortenedAddressAsync(string shortenedAddress)
        {
            return await _context.Urls.SingleOrDefaultAsync(u => u.ShortenedAddress == shortenedAddress);
        }
    }
}