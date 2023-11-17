using System.ComponentModel.DataAnnotations;

namespace ParkApi.model
{
    public class Parks
    {
        [Key]
        public int Id { get; set; }
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public string ParkDescription { get; set; }
        public string ImageUrl { get; set; }
        public FeaturesList? Features { get; set; }
        public LocationDetail? Location { get; set; }

    }
}