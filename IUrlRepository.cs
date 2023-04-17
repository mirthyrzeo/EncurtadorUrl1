using System.Threading.Tasks;
using Encurtador.Core.Models;

namespace Encurtador.Core.Interfaces
{
    public interface IUrlRepository
    {
        Task AddAsync(Url url);
        Task<Url> GetByShortenedAddressAsync(string shortenedAddress);
    }
}