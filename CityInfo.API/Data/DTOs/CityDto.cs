namespace CityInfo.API.Data.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumOfHospital
        {
            get
            {
                return Hospitals.Count;
            }
        }

        public ICollection<HospitalDto> Hospitals { get; set; }
            = new List<HospitalDto>();
    }
}
