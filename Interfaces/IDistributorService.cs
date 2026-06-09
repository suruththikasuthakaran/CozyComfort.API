using CozyComfort.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Interfaces
{
    public interface IDistributorService
    {
        Task<IEnumerable<Distributor>> GetAllDistributorsAsync();
        Task<Distributor> GetDistributorByIdAsync(int id);
        Task<Distributor> AddDistributorAsync(Distributor distributor);
        Task<bool> ProcessOrderAsync(int distributorId, int blanketId, int quantity, int sellerId);
    }
}
