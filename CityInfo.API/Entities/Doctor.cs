using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Online { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Specialization { get; set; }
        public string? Sex { get; set; }
        public string? YearsExperience { get; set;}

        //Navigation
        [ForeignKey("HospitalId")]
        public Hospital? PPA { get; set; }
        public int HospitalId { get; set; }
    }
}
