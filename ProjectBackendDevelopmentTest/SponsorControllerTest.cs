using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProjectBackendDevelopment.DTO;
using ProjectBackendDevelopment.Models;
using Xunit;

namespace ProjectBackendDevelopmentTest
{
    public class SponsorControllerTest : IClassFixture<WebApplicationFactory<ProjectBackendDevelopment.Startup>>
    {
        public HttpClient Client { get; set; }

        public SponsorControllerTest(WebApplicationFactory<ProjectBackendDevelopment.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Sponsors_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/sponsors");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var brands = JsonConvert.DeserializeObject<List<Sponsor>>(await response.Content.ReadAsStringAsync());
            Assert.True(brands.Count > 0);
        }

        [Fact]
        public async Task Get_Players_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/players");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var players = JsonConvert.DeserializeObject<List<PlayerDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(players.Count > 0);
        }
        [Fact]
        public async Task Get_Teams_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/teams");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var teams = JsonConvert.DeserializeObject<List<TeamDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(teams.Count > 0);
        }

        [Fact]
        public async Task Get_Rugnummers_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/rugnummers");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var rugnummers = JsonConvert.DeserializeObject<List<RugNummer>>(await response.Content.ReadAsStringAsync());
            Assert.True(rugnummers.Count > 0);
        }

        [Fact]
        public async Task Get_Specific_Sponsor_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/sponsor/874df1d3-33e1-405f-2918-08d90b9f3372");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var sponsors = JsonConvert.DeserializeObject<Sponsor>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(sponsors);
        }

        [Fact]
        public async Task Add_Sponsor_Test()
        {
            var sneaker=new SponsorDTO()            
            {
                Name= "Adidas",
                TeamId= 2,
                Players= new List<int>()
            };
            string json=JsonConvert.SerializeObject(sneaker);
            var response=await Client.PostAsync("/api/sponsors", new StringContent(json,Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdSponsor=JsonConvert.DeserializeObject<SponsorDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdSponsor);
        }
    }
}
