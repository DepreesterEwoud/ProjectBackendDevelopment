using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers();
    }

    public class PlayerRepository : IPlayerRepository
    {
        private ISponsorContext _context;
        public PlayerRepository(ISponsorContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }
    }
}
