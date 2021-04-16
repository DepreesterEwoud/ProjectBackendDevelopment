using System;
using System.Collections.Generic;

namespace ProjectBackendDevelopment.DTO
{
    public class SponsorDTO
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public List<int> Players { get; set; }
    }
}
