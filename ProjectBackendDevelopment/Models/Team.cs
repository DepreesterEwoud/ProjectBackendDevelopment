using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectBackendDevelopment.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [JsonIgnore]
        public List<Sponsor> Sponsors { get; set; }
    }
}
