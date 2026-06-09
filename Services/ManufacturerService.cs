using CozyComfort.API.Data;
using CozyComfort.API.Interfaces;
using CozyComfort.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly AppDbContext _context;

        public ManufacturerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBlanketAsync(Blanket blanket)
        {
            _context.Blankets.Add(blanket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Blanket>> GetAllBlanketsAsync()
        {
            return await _context.Blankets.ToListAsync();
        }

        public async Task<Blanket> GetBlanketByIdAsync(int id)
        {
            return await _context.Blankets.FindAsync(id);
        }

        public async Task<bool> UpdateBlanketStockAsync(int blanketId, int quantity)
        {
            var blanket = await _context.Blankets.FindAsync(blanketId);
            if (blanket == null) return false;

            blanket.Stock += quantity; // Can be positive (produce) or negative (fulfill order)
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
