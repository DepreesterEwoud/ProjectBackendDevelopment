using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectBackendDevelopment.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [JsonIgnore]
        public List<SponsorPlayer> SponsorPlayers { get; set; }
    }
}
