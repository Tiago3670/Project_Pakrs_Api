using System.ComponentModel.DataAnnotations;

namespace ParkApi.model
{
    public class FeaturesList
    {
        [Required]
        [Key]
        public int FeaturesListId { get; set; }

        public bool? Food { get; set; }

        public bool? Shops { get; set; }

        public bool? Entertainment { get; set; }

        public bool? Gym { get; set; }

        public bool? WiFi { get; set; }

        public bool? PetsAllowed { get; set; }

    }
}