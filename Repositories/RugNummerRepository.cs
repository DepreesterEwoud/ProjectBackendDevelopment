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
    }
}
