using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        //Navigation property
        //Initialize the hospitals to an empty list to avoid Null excep issues when u are manipulating this and hospital is not loaded
        public ICollection<Hospital> Hospitals { get; set; }
            = new List<Hospital>();

        //Contructor, so city class always has a Name value
        public City(string name)
        {
            Name = name;
        }
    }
}
