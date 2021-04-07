using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjectBackendDevelopment.DTO;
using ProjectBackendDevelopment.Models;
using ProjectBackendDevelopment.Repositories;

namespace ProjectBackendDevelopment.Services
{
    public interface ISponsorService
    {
        Task<SponsorDTO> AddSponsor(SponsorDTO sponsor);
        Task<List<PlayerDTO>> GetPlayers();
        Task<Sponsor> GetSponsor(Guid sponsorId);
        Task<List<Sponsor>> GetSponsors();
        Task<List<TeamDTO>> GetTeams();
    }

    public class SponsorService : ISponsorService
    {
        private IPlayerRepository _playerRepository;
        private ISponsorRepository _sponsorRepository;
        private ITeamRepository _teamRepository;
        private IRugNummerRepository _rugnummerRepository;
        private IMapper _mapper;

        public SponsorService(IMapper mapper, IPlayerRepository playerRepository, ISponsorRepository sponsorRepository, ITeamRepository teamRepository, IRugNummerRepository rugnummerRepository)
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
            _sponsorRepository = sponsorRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Sponsor> GetSponsor(Guid sponsorId)
        {
            try
            {
                return await _sponsorRepository.GetSponsor(sponsorId);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Sponsor>> GetSponsors()
        {
            return await _sponsorRepository.GetSponsors();
        }
        public async Task<SponsorDTO> AddSponsor(SponsorDTO sponsor)
        {
            try
            {

                Sponsor newSponsor = _mapper.Map<Sponsor>(sponsor);

                newSponsor.SponsorPlayers = new List<SponsorPlayer>();
                foreach (var playerid in sponsor.Players)
                {
                    newSponsor.SponsorPlayers.Add(new SponsorPlayer() { PlayerId = playerid });
                }
                await _sponsorRepository.AddSneaker(newSponsor);
                return sponsor;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TeamDTO>> GetTeams()
        {
            return _mapper.Map<List<TeamDTO>>(await _teamRepository.GetTeams());
        }
        public async Task<List<PlayerDTO>> GetPlayers()
        {
            return _mapper.Map<List<PlayerDTO>>(await _playerRepository.GetPlayers());
        }
    }
}
