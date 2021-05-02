using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeams();
        Task<Team> AddTeam(Team addTeam);
    }

    public class TeamRepository : ITeamRepository
    {
        private ISponsorContext _context;
        public TeamRepository(ISponsorContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }
        public async Task<Team> AddTeam(Team addTeam)
        {
            await _context.Teams.AddAsync(addTeam);
            await _context.SaveChangesAsync();
            return addTeam;
        }
    }
}
