using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.DTO;
using ProjectBackendDevelopment.Models;
using ProjectBackendDevelopment.Services;

namespace ProjectBackendDevelopment.Controllers
{
    [ApiController]
    [Route("api")]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorService _sponsorService;
        private readonly ILogger<SponsorController> _logger;
        public SponsorController(ILogger<SponsorController> logger,ISponsorService sponsorService)
        {
            _logger = logger;
            _sponsorService = sponsorService;
        }

        [HttpGet]
        [Route("players")]
        public async Task<ActionResult<List<PlayerDTO>>> GetPlayers()
        {
            try{
                return new OkObjectResult(await _sponsorService.GetPlayers());
            }
            catch(System.Exception ex){
                throw ex;
            }
        }
        [HttpGet]
        [Route("teams")]
        public async Task<ActionResult<List<TeamDTO>>> GetTeams()
        {
            try{
                return new OkObjectResult(await _sponsorService.GetTeams());
            }
            catch(System.Exception ex){
                throw ex;
            }
        }
        [HttpGet]
        [Route("sponsors")]
        public async Task<ActionResult<List<Sponsor>>> GetSponsors()
        {
            try{
                return new OkObjectResult(await _sponsorService.GetSponsors());
            }
            catch(System.Exception ex){
                throw ex;
            }
        }
        [HttpGet]
        [Route("sponsor/{sponsorId}")]
        public async Task<ActionResult<List<Sponsor>>> GetSponsor(Guid sponsorId)
        {
            try{
                return new OkObjectResult(await _sponsorService.GetSponsor(sponsorId));
            }
            catch(System.Exception ex){
                throw ex;
            }
        }

        [HttpPost]
        [Route("sponsors")]
        public async Task<ActionResult<SponsorDTO>> AddSponsor(SponsorDTO sponsor)
        {
            try{
                return new OkObjectResult(await _sponsorService.AddSponsor(sponsor));
            }
            catch(System.Exception ex){
                throw ex;
            }
        }
    }
}
