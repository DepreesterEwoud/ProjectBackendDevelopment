using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectBackendDevelopment.Models
{
    public class Sponsor
    {
        public Guid SponsorId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public List<SponsorPlayer> SponsorPlayers { get; set; }

    }
}
