using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.DTO;
using ProjectBackendDevelopment.Models;
using ProjectBackendDevelopment.Services;

namespace ProjectBackendDevelopment.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [Route("rugnummers")]
        public async Task<ActionResult<List<RugNummer>>> GetRugnummers()
        {
            try{
                return new OkObjectResult(await _sponsorService.GetRugnummers());
            }
            catch(System.Exception ex){
                throw ex;
            }
        }

        [HttpPut]
        [Route("rugnummer")]
        public async Task<ActionResult<RugNummer>> UpdateRugnummer(RugNummer rugnummer)
        {
            try
            {
                return new OkObjectResult(await _sponsorService.UpdateRugnummer(rugnummer));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
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
