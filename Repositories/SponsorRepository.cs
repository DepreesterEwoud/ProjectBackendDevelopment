using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.Repositories
{
    public interface ISponsorRepository
    {
        Task<Sponsor> AddSneaker(Sponsor sponsor);
        Task<Sponsor> GetSponsor(Guid sponsorId);
        Task<List<Sponsor>> GetSponsors();
    }

    public class SponsorRepository : ISponsorRepository
    {
        private ISponsorContext _context;
        public SponsorRepository(ISponsorContext context)
        {
            _context = context;
        }
        public async Task<List<Sponsor>> GetSponsors()
        {
            return await _context.Sponsors.Include(s => s.SponsorPlayers).Include(s => s.Team).ToListAsync();
        }
        public async Task<Sponsor> AddSneaker(Sponsor sponsor)
        {
            await _context.Sponsors.AddAsync(sponsor);
            await _context.SaveChangesAsync();
            return sponsor;
        }

        public async Task<Sponsor> GetSponsor(Guid sponsorId)
        {
            return await _context.Sponsors.Where(s => s.SponsorId == sponsorId)
            .Include(s => s.Team)
            .Include(s => s.SponsorPlayers)
            .ThenInclude(s => s.Player).SingleOrDefaultAsync();
        }
    }
}
