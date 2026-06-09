using CozyComfort.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<Seller>> GetAllSellersAsync();
        Task<Seller> GetSellerByIdAsync(int id);
        Task<Seller> AddSellerAsync(Seller seller);
        Task<Order> PlaceOrderAsync(int sellerId, int distributorId, int blanketId, int quantity);
        Task<IEnumerable<Order>> GetOrdersForSellerAsync(int sellerId);
    }
}
