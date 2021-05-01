using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectBackendDevelopment.Models
{
    public class RugNummer
    {
        [Key]
        public int RugId { get; set; }
        public int RugNummerCijfer { get; set; }
        [JsonIgnore]
        public Player Player { get; set; }
    }
}
