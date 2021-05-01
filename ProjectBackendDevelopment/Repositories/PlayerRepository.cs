using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers();
        Task<Player> GetPlayerByName(string name);
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
            try{
                return await _context.Players.ToListAsync();
            }
            catch(System.Exception ex){
                throw ex;
            }
            
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            try
            {
                return await _context.Players.Where(a => a.FirstName == name).SingleOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
