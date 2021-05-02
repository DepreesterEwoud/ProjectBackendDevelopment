using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.Repositories
{
    public interface IRugNummerRepository
    {
        Task<List<RugNummer>> GetRugNummers();
        Task<RugNummer> UpdateRugnummer(RugNummer rugnummer);
        Task<RugNummer> AddRugNummer(RugNummer addRugnummer);
    }

    public class RugNummerRepository : IRugNummerRepository
    {
        private ISponsorContext _context;
        public RugNummerRepository(ISponsorContext context)
        {
            _context = context;
        }

        public async Task<List<RugNummer>> GetRugNummers()
        {
            return await _context.RugNummers.ToListAsync();
        }

        public async Task<RugNummer> UpdateRugnummer(RugNummer rugnummer)
        {
            _context.RugNummers.Update(rugnummer);
            await _context.SaveChangesAsync();
            return rugnummer;
        }
        public async Task<RugNummer> AddRugNummer(RugNummer addRugnummer)
        {
            await _context.RugNummers.AddAsync(addRugnummer);
            await _context.SaveChangesAsync();
            return addRugnummer;
        }
    }
}
