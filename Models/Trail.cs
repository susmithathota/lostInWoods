using System.ComponentModel.DataAnnotations;
namespace lostInWoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public int trailId { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
        [Required]
        [Range(0,10000)]
        public double Length { get; set; }
        
        [Range(0,10000)]
        public double Elevation { get; set; }

        [Range(0,10000)]
        public double Latitude { get; set; }

        [Range(0,10000)]
        public double Longitude { get; set; }
        
    }
}
