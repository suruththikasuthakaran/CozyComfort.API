using CozyComfort.API.Data;
using CozyComfort.API.Interfaces;
using CozyComfort.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly AppDbContext _context;
        private readonly IManufacturerService _manufacturerService;

        public DistributorService(AppDbContext context, IManufacturerService manufacturerService)
        {
            _context = context;
            _manufacturerService = manufacturerService;
        }

        public async Task<IEnumerable<Distributor>> GetAllDistributorsAsync()
        {
            return await _context.Distributors.ToListAsync();
        }

        public async Task<Distributor> GetDistributorByIdAsync(int id)
        {
            return await _context.Distributors.FindAsync(id);
        }

        public async Task<Distributor> AddDistributorAsync(Distributor distributor)
        {
            _context.Distributors.Add(distributor);
            await _context.SaveChangesAsync();
            return distributor;
        }

        public async Task<bool> ProcessOrderAsync(int distributorId, int blanketId, int quantity, int sellerId)
        {
            // Simple logic: If manufacturer has stock, fulfill it.
            // In a real scenario, the distributor would hold their own stock.
            var blanket = await _manufacturerService.GetBlanketByIdAsync(blanketId);
            if (blanket == null || blanket.Stock < quantity)
            {
                return false; // Not enough stock at manufacturer
            }

            // Deduct from manufacturer
            await _manufacturerService.UpdateBlanketStockAsync(blanketId, -quantity);
            return true;
        }
    }
}
