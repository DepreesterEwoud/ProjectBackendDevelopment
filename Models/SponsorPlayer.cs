using System;
using System.Text.Json.Serialization;

namespace ProjectBackendDevelopment.Models
{
    public class SponsorPlayer
    {
        public Guid SponsorId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
