using CityInfo.API.Entities;

namespace CityInfo.API.Data.DTOs
{

        public class DoctorDTO
        {
        public bool Online { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }
        public string? Sex { get; set; }
        public string? YearsExperience { get; set; }
        public int HospitalId { get; set; }
        public HospitalDto HospitalOfPrimatyAssighnment { get; set; }
        }

}
