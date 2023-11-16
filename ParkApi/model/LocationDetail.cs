using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.ComponentModel.DataAnnotations;

namespace ParkApi.model
{
    public class LocationDetail
    {
        [Required]
        [Key]
        public int LocationId { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
        public string? Coodinates { get; set; }

    }
}