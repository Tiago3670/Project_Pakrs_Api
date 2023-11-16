using System.ComponentModel.DataAnnotations;

namespace ParkApi.model
{
    public class Users
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}