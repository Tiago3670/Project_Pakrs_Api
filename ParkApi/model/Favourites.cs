using System.ComponentModel.DataAnnotations;

namespace ParkApi.model
{
    public class Favourites
    {

        public int UserId { get; set; }

        public int ParkId { get; set; }
    }
}