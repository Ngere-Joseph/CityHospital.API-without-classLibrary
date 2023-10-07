using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Entities
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hospital Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? HospitalType { get; set; }

        //Navigation properties
        [ForeignKey("CityId")]
        public City? City { get; set; }
        public int CityId { get; set; }

        public ICollection<Doctor> Doctors { get; set; } 
            = new List<Doctor>();

        //Contructor, so city class always has a Name value
        public Hospital(string name)
        {
            Name = name;
        }
    }
}
