using System.ComponentModel.DataAnnotations;

namespace ParkApi.model
{
    public class Parks
    {
        [Key]
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public string ParkDescription { get; set; }
        public string ImageUrl { get; set; }
        public FeaturesList FeaturesID { get; set; }
        public LocationDetail LocationID { get; set; }



    }
}