using CozyComfort.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Interfaces
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Blanket>> GetAllBlanketsAsync();
        Task<Blanket> GetBlanketByIdAsync(int id);
        Task<bool> AddBlanketAsync(Blanket blanket);
        Task<bool> UpdateBlanketStockAsync(int blanketId, int quantity);
    }
}
