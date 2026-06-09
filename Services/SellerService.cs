using CozyComfort.API.Data;
using CozyComfort.API.Interfaces;
using CozyComfort.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozyComfort.API.Services
{
    public class SellerService : ISellerService
    {
        private readonly AppDbContext _context;
        private readonly IDistributorService _distributorService;

        public SellerService(AppDbContext context, IDistributorService distributorService)
        {
            _context = context;
            _distributorService = distributorService;
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            return await _context.Sellers.FindAsync(id);
        }

        public async Task<Seller> AddSellerAsync(Seller seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            return seller;
        }

        public async Task<Order> PlaceOrderAsync(int sellerId, int distributorId, int blanketId, int quantity)
        {
            var order = new Order
            {
                SellerId = sellerId,
                DistributorId = distributorId,
                BlanketId = blanketId,
                Quantity = quantity,
                Status = "Pending"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var isFulfilled = await _distributorService.ProcessOrderAsync(distributorId, blanketId, quantity, sellerId);
            
            if (isFulfilled)
            {
                order.Status = "Fulfilled";
            }
            else
            {
                order.Status = "Rejected - Insufficient Stock";
            }

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersForSellerAsync(int sellerId)
        {
            return await _context.Orders
                .Include(o => o.Blanket)
                .Include(o => o.Distributor)
                .Where(o => o.SellerId == sellerId)
                .ToListAsync();
        }
    }
}
